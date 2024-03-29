﻿using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.DataAccessHandlers;
using BTSuggestions.Core.Interfaces.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Engines
{
    public class ContentEngine : IContentEngine
    {
        
        private readonly IContentHandler _contentHandler;
        public ContentEngine(IContentHandler contentHandler)
        {
            _contentHandler = contentHandler;
        }

        public async Task<ContentEntity> CreateContent(ContentEntity content)
        {
            var results = await _contentHandler.GetContents();
            if (results.Count() == 0)
            {
                await _contentHandler.Insert(content);
                await _contentHandler.SaveChanges();
                return content;
            }
            var result = results.First(x => x.UserId == content.UserId);
            if (result == null)
            {
                await _contentHandler.Insert(content);
                await _contentHandler.SaveChanges();
            }
            else
            {
                await UpdateContent(result.Id, content);
            }

            return content;
        }

        public async Task<Task> DeleteContent(ContentEntity content)
        {
            await _contentHandler.Delete(content);
            return Task.CompletedTask;
        }

        public async Task<ContentEntity> GetContent(int id)
        {
            return await _contentHandler.GetContent(id);
        }

        public async Task<string> GetContentById(int id)
        {
            return await _contentHandler.GetContentById(id);
        }

        public async Task<string> GetContentByUser(int id)
        {
            return await _contentHandler.GetContentByUser(id);
        }

        public async Task<IEnumerable<ContentEntity>> GetContents()
        {
            return await _contentHandler.GetContents();
        }

        public async Task<UserEntity> GetUser(int id)
        {
            return await _contentHandler.GetUser(id);
        }

        public async Task<ContentEntity> UpdateContent(int id, ContentEntity content)
        {
            ContentEntity result = await _contentHandler.GetById(id);
            result.User = await _contentHandler.GetUser(content.UserId);
            result.Content = content.Content;
            result.UserId = content.UserId;
            await _contentHandler.SaveChanges();
            return result;
        }
    }
}
