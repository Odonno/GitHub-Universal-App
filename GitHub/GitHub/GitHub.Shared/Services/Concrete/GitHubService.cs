﻿using System;
using System.Threading.Tasks;
using GitHub.ViewModel;
using Octokit;
using GitHub.Services.Abstract;

namespace GitHub.Services.Concrete
{
    public class GitHubService : IGitHubService
    {
        private readonly IGitHubClient _client;

        public GitHubService()
        {
            _client = ViewModelLocator.GitHubClient;
        }

        #region Get single item

        public async Task<User> GetCurrentUserAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserAsync(string name)
        {
            try
            {
                return await _client.User.Get(name);
            }
            catch (NotFoundException)
            {
                return null;
            }
        }

        public async Task GetActivitiesAsync()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Search items

        public async Task<SearchUsersResult> SearchUsersAsync(string searchName, int page = 1, int elementPerPage = 100)
        {
            return await _client.Search.SearchUsers(new SearchUsersRequest(searchName)
            {
                Page = page,
                PerPage = elementPerPage
            });
        }

        public async Task<SearchRepositoryResult> SearchReposAsync(string searchName, int page = 1, int elementPerPage = 100)
        {
            return await _client.Search.SearchRepo(new SearchRepositoriesRequest(searchName)
            {
                Page = page,
                PerPage = elementPerPage
            });
        }

        #endregion
    }
}