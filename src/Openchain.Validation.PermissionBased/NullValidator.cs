﻿// Copyright 2015 Coinprism, Inc.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Openchain.Ledger;
using Openchain.Ledger.Validation;

namespace Openchain.Validation.PermissionBased
{
    public class NullValidator : IMutationValidator
    {
        private readonly bool alwaysValid;

        public NullValidator(bool alwaysValid)
        {
            this.alwaysValid = alwaysValid;
        }

        public Task Validate(ParsedMutation mutation, IReadOnlyList<SignatureEvidence> authentication, IReadOnlyDictionary<AccountKey, AccountStatus> accounts)
        {
            if (this.alwaysValid)
                return Task.FromResult(0);
            else
                throw new TransactionInvalidException("Disabled");
        }
    }
}