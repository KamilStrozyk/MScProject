using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MScProject.Services.DTO;
using MScProject.Services.Services.Interfaces;
using Npgsql;

namespace MScProject.Services.Services
{
    public class TaskListService : ITaskListService
    {
        private readonly string connectionString;

        public TaskListService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DB");
        }

        public IEnumerable<TaskListDTO> GetAllTaskLists()
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var query = "SELECT * FROM task_list";
            var command = new NpgsqlCommand(query, connection);
            var result = command.ExecuteReader();
            while (result.Read())
            {
                yield return new TaskListDTO
                {
                    Id = result.GetInt64(0),
                    Title = result.GetString(1),
                    CreatedAt = result.GetDateTime(2)
                };
            }
        }

        public TaskListDTO Get(long id)
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var query = $"SELECT * FROM task_list WHERE id = {id}";
            var command = new NpgsqlCommand(query, connection);
            var result = command.ExecuteReader();
            result.Read();
            return new TaskListDTO
            {
                Id = result.GetInt64(0),
                Title = result.GetString(1),
                CreatedAt = result.GetDateTime(2)
            };
        }

        public IEnumerable<TaskDTO> GetTasks(long id)
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var query = $"SELECT * FROM task WHERE list_id = {id}";
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

        public void Create(TaskListDTO taskList)
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var query =
                $"INSERT INTO task_list(id,title,created_at) VALUES({taskList.Id}, '{taskList.Title}', '{taskList.CreatedAt}')";
            var command = new NpgsqlCommand(query, connection);
            var result = command.ExecuteNonQuery();
            if (result == 0) throw new InvalidOperationException();
        }

        public void Update(TaskListDTO taskList)
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var query =
                $"UPDATE task_list SET title = '{taskList.Title}', created_at = '{taskList.CreatedAt}' WHERE id = {taskList.Id}";
            var command = new NpgsqlCommand(query, connection);
            var result = command.ExecuteNonQuery();
            if (result == 0) throw new InvalidOperationException();
        }

        public void Delete(long id)
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var query = $"DELETE FROM task_list WHERE id = {id}";
            var command = new NpgsqlCommand(query, connection);
            var result = command.ExecuteNonQuery();
            if (result == 0) throw new InvalidOperationException();
        }
    }
}