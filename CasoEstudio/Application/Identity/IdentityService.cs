﻿using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IAccountService _authenticationService;

        public IdentityService(IAccountService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public Task<bool> HasAccess(string email, string controller, string action)
        {
            throw new NotImplementedException();
        }


        public async Task<Result> Signup(string email, string password)
        {
            return await _authenticationService.Signin(email, password); 
        }
        public async Task<Result> Signin(string email, string password)
        {
            return await _authenticationService.Signin(email, password);
        }
        public async Task Signout()
        {
            await _authenticationService.Signout();
        }
        
    }
}
