using System;
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
                LogingService.LoggingServices.Instance.WriteLine<FilmRepository>($"Try read from {FileName}");
                jsonLines = await FileIO.ReadLinesAsync(store);
            }
            finally
            {
                LogingService.LoggingServices.Instance.WriteLine<FilmRepository>($"Final read from {FileName}");
                _locker.Release();
            }

            if(jsonLines == null)
            {
                return null;
            }

            if(jsonLines.Count == 0)
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

        public async void Insert(FilmInfo item)
        {
            string json = JsonConvert.SerializeObject(item);
            StorageFile store = await GetStorage();

            await _locker.WaitAsync();
            try
            {
                LogingService.LoggingServices.Instance.WriteLine<FilmRepository>($"Try insert film: {item.Title}");
                await FileIO.AppendTextAsync(store, json);
                await FileIO.AppendTextAsync(store, "\n");
            }
            finally
            {
                _locker.Release();
                LogingService.LoggingServices.Instance.WriteLine<FilmRepository>($"Film was insert: {item.Title}");
            }
        }

        private async Task<StorageFile> GetStorage()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile storageFile = await ApplicationData.Current.LocalFolder.GetFileAsync(FileName);
            return storageFile;
        }
    }
}