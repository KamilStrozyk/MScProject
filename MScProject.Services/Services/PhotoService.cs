using System;
using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }

        public PhotoDTO Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TaskDTO> GetTasks(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(PhotoDTO photo)
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var query =
                $"INSERT INTO photo(id,content) VALUES({photo.Id}, @content)";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("content", photo.Content);
            var result = command.ExecuteNonQuery();
            if (result == 0) throw new InvalidOperationException();
        }

        public void Update(PhotoDTO photo)
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var query =
                $"UPDATE photo SET content = '{photo.Content}' WHERE id = {photo.Id}";
            var command = new NpgsqlCommand(query, connection);
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