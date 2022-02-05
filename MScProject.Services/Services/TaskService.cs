using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MScProject.Services.DTO;
using MScProject.Services.Services.Interfaces;
using Npgsql;

namespace MScProject.Services.Services
{
    public class TaskService : ITaskService
    {
        private readonly string connectionString;

        public TaskService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DB");
        }

        public IEnumerable<TaskDTO> GetAllTasks()
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var query = "SELECT * FROM task";
            var command = new NpgsqlCommand(query, connection);
            var result = command.ExecuteReader();
            while (result.Read())
            {
                yield return new TaskDTO
                {
                    Id = result.GetInt64(0),
                    ListId = result.GetInt64(1),
                    Title = result.GetString(2),
                    Description = result.GetString(3),
                    CreatedAt = result.GetDateTime(4)
                };
            }
        }

        public TaskDTO Get(long id)
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var query = $"SELECT * FROM task WHERE id={id}";
            var command = new NpgsqlCommand(query, connection);
            var result = command.ExecuteReader();
            result.Read();
            return new TaskDTO
            {
                Id = result.GetInt64(0),
                ListId = result.GetInt64(1),
                Title = result.GetString(2),
                Description = result.GetString(3),
                CreatedAt = result.GetDateTime(4)
            };
        }

        public IEnumerable<PhotoDTO> GetTasksPhotos(long id)
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var query = $"SELECT photo.id, photo.content FROM task WHERE task_id = {id}";
            var command = new NpgsqlCommand(query, connection);
            var result = command.ExecuteReader();
            while (result.Read())
            {
                var bufferSize = 1024;
                var buffer = new byte[bufferSize];
                result.GetBytes(2, 0, buffer, 0, bufferSize);
                yield return new PhotoDTO()
                {
                    Id = result.GetInt64(0),
                    Content = buffer,
                };
            }
        }

        public void Create(TaskDTO task)
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var query =
                $"INSERT INTO task(id, list_id, title, description, created_at) VALUES({task.Id}, {task.ListId}, '{task.Title}', '{task.Description}', '{task.CreatedAt}')";
            var command = new NpgsqlCommand(query, connection);
            var result = command.ExecuteNonQuery();
            if (result == 0) throw new InvalidOperationException();
        }

        public void Update(TaskDTO task)
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var query =
                $"UPDATE task SET title = '{task.Title}', created_at = '{task.CreatedAt}', description = '{task.Description}', list_id = {task.ListId} WHERE id = {task.Id}";
            var command = new NpgsqlCommand(query, connection);
            var result = command.ExecuteNonQuery();
            if (result == 0) throw new InvalidOperationException();
        }

        public void Delete(long id)
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            
            // var query = $"DELETE FROM task_photo WHERE task_id = {id}";
            // var command = new NpgsqlCommand(query, connection);
            // var result = command.ExecuteNonQuery();
            //
            var query = $"DELETE FROM task WHERE id = {id}";
            var command = new NpgsqlCommand(query, connection);
            var result = command.ExecuteNonQuery();
            if (result == 0) throw new InvalidOperationException();
        }

        public void Unassign(long id, long photoId)
        {
            throw new System.NotImplementedException();
        }

        public void Assign(long id, long photoId)
        {
            throw new System.NotImplementedException();
        }
    }
}