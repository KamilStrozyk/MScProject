using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using MScProject.Services.DTO;
using MScProject.Services.Services.Interfaces;
using Npgsql;

namespace MScProject.Services.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly string connectionString;

        public PhotoService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DB");
        }

        public IEnumerable<PhotoDTO> GetAllPhotos()
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var query = "SELECT * FROM photo";
            var command = new NpgsqlCommand(query, connection);
            var result = command.ExecuteReader();
            while (result.Read())
            {
                var bufferSize = 1024;
                var buffer = new byte[bufferSize];
                result.GetBytes(1, 0, buffer, 0, bufferSize);
                yield return new PhotoDTO()
                {
                    Id = result.GetInt64(0),
                    Content = Encoding.ASCII.GetString(buffer),
                };
            }
        }

        public PhotoDTO Get(long id)
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var query = $"SELECT * FROM photo where id = {id}";
            var command = new NpgsqlCommand(query, connection);
            var result = command.ExecuteReader();
            
            result.Read();
            var bufferSize = 1024;
            var buffer = new byte[bufferSize];
            result.GetBytes(1, 0, buffer, 0, bufferSize);
            return new PhotoDTO()
            {
                Id = result.GetInt64(0),
                Content = Encoding.ASCII.GetString(buffer),
            };
        }

        public IEnumerable<TaskDTO> GetTasks(long id)
        {
            // using var connection = new NpgsqlConnection(connectionString);
            // connection.Open();
            // var query = $"SELECT photo.id, photo.content FROM task WHERE task_id = {id}";
            // var command = new NpgsqlCommand(query, connection);
            // var result = command.ExecuteReader();r
            return null;
        }

        public void Create(PhotoDTO photo)
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var query =
                $"INSERT INTO photo(id,content) VALUES({photo.Id}, @content)";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("content", Encoding.ASCII.GetBytes(photo.Content));
            var result = command.ExecuteNonQuery();
            if (result == 0) throw new InvalidOperationException();
        }

        public void Update(PhotoDTO photo)
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var query =
                $"UPDATE photo SET content =  @content WHERE id = {photo.Id}";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("content", Encoding.ASCII.GetBytes(photo.Content));
            var result = command.ExecuteNonQuery();
            if (result == 0) throw new InvalidOperationException();
        }

        public void Delete(long id)
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            // var query = $"DELETE FROM task_photo WHERE photo_id = {id}";
            // var command = new NpgsqlCommand(query, connection);
            // var result = command.ExecuteNonQuery();

            var query = $"DELETE FROM photo WHERE id = {id}";
            var command = new NpgsqlCommand(query, connection);
            var result = command.ExecuteNonQuery();
            if (result == 0) throw new InvalidOperationException();
        }
    }
}