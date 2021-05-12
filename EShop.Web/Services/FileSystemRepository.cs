using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Web.Services
{
    public class FileSystemRepository<T> : IRepository<T> where T : IIdentifiable
    {
        private string path = @"C:\temp\e-Shop\";

        public void Add(T entity)
        {
            string listaSerializata;
            string fileName = typeof(T).Name + ".json";
            if (!File.Exists(path + fileName))
            {
                using (StreamWriter streamWriter = File.CreateText(path + fileName))
                {
                    streamWriter.Write("[]");
                }
            }
            using (StreamReader streamReader = File.OpenText(path + fileName)) 
            {
                int celMaiMareID = 0;
                listaSerializata = streamReader.ReadToEnd();
                List<T> listaDeserializata = JsonConvert.DeserializeObject<List<T>>(listaSerializata);
                for (int i = 0; i < listaDeserializata.Count; i++)
                {
                    T element = listaDeserializata[i];

                    if (celMaiMareID < element.Id)
                    {
                        celMaiMareID = element.Id;
                    }
                }
                entity.Id = ++celMaiMareID;
                listaDeserializata.Add(entity);
                listaSerializata = JsonConvert.SerializeObject(listaDeserializata);
            }
            File.WriteAllText(path + fileName, listaSerializata);
        }

        public IEnumerable<T> GetAll()
        {
            List<T> listaDeserializata;
            string fileName = typeof(T).Name + ".json";
            if (!File.Exists(path + fileName))
            {
                using (StreamWriter streamWriter = File.CreateText(path + fileName))
                {
                    streamWriter.Write("[]");
                }
            }
            using (StreamReader streamReader = File.OpenText(path + fileName))
            {
                string listaSerializata = streamReader.ReadToEnd();
                listaDeserializata = JsonConvert.DeserializeObject<List<T>>(listaSerializata);
            }
            return listaDeserializata;
        }

        public T GetById(int id)
        {
            List<T> listaDeserializata;
            string fileName = typeof(T).Name + ".json";
            using (StreamReader streamReader = File.OpenText(path + fileName))
            {
                string listaSerializata = streamReader.ReadToEnd();
                listaDeserializata = JsonConvert.DeserializeObject<List<T>>(listaSerializata);
            }

            for (int i = 0; i < listaDeserializata.Count; i++)
            {
                T element = listaDeserializata[i];
                if (element.Id == id)
                {
                    return element;
                }
            }

           throw new Exception("not found by ID");
        }

        public void Remove(int id)
        {
            string listaSerializata;
            string fileName = typeof(T).Name + ".json";

            using (StreamReader streamReader = File.OpenText(path + fileName))
            {
                listaSerializata = streamReader.ReadToEnd();
                List<T> listaDeserializata = JsonConvert.DeserializeObject<List<T>>(listaSerializata);
                for (int i = 0; i < listaDeserializata.Count; i++)
                {
                    T element = listaDeserializata[i];

                    if (element.Id == id)
                    {
                        listaDeserializata.Remove(element);
                    }
                }
                listaSerializata = JsonConvert.SerializeObject(listaDeserializata);
            }

            File.WriteAllText(path + fileName, listaSerializata);
        }

        public void Update(T updateEntity, int id)
        {
            string listaSerializata;
            string fileName = typeof(T).Name + ".json";

            using (StreamReader streamReader = File.OpenText(path + fileName))
            {
                listaSerializata = streamReader.ReadToEnd();
                List<T> listaDeserializata = JsonConvert.DeserializeObject<List<T>>(listaSerializata);
                for (int i = 0; i < listaDeserializata.Count; i++)
                {
                    T element = listaDeserializata[i];

                    if (element.Id == id)
                    {
                        listaDeserializata[i] = updateEntity;
                    }
                }
                listaSerializata = JsonConvert.SerializeObject(listaDeserializata);
            }

            File.WriteAllText(path + fileName, listaSerializata);

        }
    }
}

