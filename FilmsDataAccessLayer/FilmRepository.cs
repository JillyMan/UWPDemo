﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FilmsDataAccessLayer.Models;
using Newtonsoft.Json;
using Windows.Storage;

namespace FilmsDataAccessLayer
{
    public class FilmRepository : IRepository<FilmInfo>
    {
        public string FileName { get; }
        private readonly SemaphoreSlim _locker = new SemaphoreSlim(1, 1);

        public FilmRepository(string fileName)
        {
            FileName = fileName;
        }

        public async Task<IEnumerable<FilmInfo>> Get()
        {
            var store = await GetStorage();
            IList<string> jsonLines = null;

            await _locker.WaitAsync();
            try
            {
                LogingService.LoggingServices.Instance.WriteLine<FilmRepository>($"-Try read from {FileName}");
                jsonLines = await FileIO.ReadLinesAsync(store);
                LogingService.LoggingServices.Instance.WriteLine<FilmRepository>($"-Finish async read: {FileName}");
            }
            finally
            {
                LogingService.LoggingServices.Instance.WriteLine<FilmRepository>($"-Final read from {FileName}");
                _locker.Release();
            }

            if(jsonLines == null || jsonLines.Count == 0)
            {
                return null;
            }

            var result = new List<FilmInfo>(jsonLines.Count);
            
            foreach(var json in jsonLines)
            {
                if (string.IsNullOrEmpty(json)) 
                {
                    continue;
                }

                result.Add(JsonConvert.DeserializeObject<FilmInfo>(json));
            }
            
            return result;
        }

        public async Task Insert(FilmInfo item)
        {
            string json = JsonConvert.SerializeObject(item);
            StorageFile store = await GetStorage();

            await _locker.WaitAsync();
            try
            {
                LogingService.LoggingServices.Instance.WriteLine<FilmRepository>($"--Try insert film: {item.Title}");
                await FileIO.AppendTextAsync(store, json);
                await FileIO.AppendTextAsync(store, "\n");
                LogingService.LoggingServices.Instance.WriteLine<FilmRepository>($"--Finish await operation for insert film: {item.Title}");
            }
            finally
            {
                _locker.Release();
                LogingService.LoggingServices.Instance.WriteLine<FilmRepository>($"--Film was insert: {item.Title}");
            }
        }

        private async Task<StorageFile> GetStorage()
        {

            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile storageFile;

            if (await localFolder.TryGetItemAsync(FileName) == null)
            {
                storageFile = await localFolder.CreateFileAsync(FileName);
            }
            else
            {
                storageFile = await localFolder.GetFileAsync(FileName);
            }

            return storageFile;
        }
    }
}