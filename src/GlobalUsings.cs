﻿// Copyright (c) Maxim Novichkov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

global using System;
global using System.Data;
global using System.Net.Http;
global using System.Net.Http.Headers;
global using System.Text;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using System.Threading.Tasks;
global using System.Xml.Serialization;
global using Dapr;
global using Dapper;
global using HealthChecks.UI.Client;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
global using Microsoft.OpenApi.Models;
global using Oracle.ManagedDataAccess.Client;
global using ParusRx.Xml;
global using ParusRx.Data.Oracle;
global using ParusRx.Data.PostgreSql;
global using ParusRx.EventBus;
global using ParusRx.Storage;
global using ParusRx.Data.Core;
global using ParusRx.DirectumRx.Models;
global using ParusRx.DirectumRx.Integration;
global using ParusRx.DirectumRx.Integration.Stores;
global using ParusRx.DirectumRx.Integration.Stores.Oracle;
global using ParusRx.DirectumRx.Integration.Stores.PostgreSql;
global using ParusRx.DirectumRx.Integration.Handlers;
global using ParusRx.DirectumRx.Services;
global using ParusRx.DirectumRx.Services.Oracle;
global using ParusRx.DirectumRx.Services.PostgreSql;
global using Serilog.Context;
