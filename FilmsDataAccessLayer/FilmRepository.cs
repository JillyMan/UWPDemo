using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FilmsDataAccessLayer.Models;
using Newtonsoft.Json;
using Windows.Storage;

namespace FilmsDataAccessLayer
{
    public class FilmRepository : IRepository<FilmInfo>
    {
        public string FileName { get; }

        public FilmRepository(string fileName)
        {
            FileName = fileName;
        }

        public async Task<IEnumerable<FilmInfo>> Get()
        {
            var store = await GetStorage();
            var jsonLines = await FileIO.ReadLinesAsync(store);

            if (jsonLines.Count == 0)
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
          await FileIO.AppendTextAsync(store, "\n");
            await FileIO.AppendTextAsync(store, json);
        }

        private async Task<StorageFile> GetStorage()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile storageFile = await ApplicationData.Current.LocalFolder.GetFileAsync(FileName);
            return storageFile;
        }
    }
}
