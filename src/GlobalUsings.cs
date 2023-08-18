// Copyright (c) Parusnik. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
global using ParusRx.Services.DirectumRx.Api.Models;
global using ParusRx.Services.DirectumRx.Api.Integration;
global using ParusRx.Services.DirectumRx.Api.Integration.Stores;
global using ParusRx.Services.DirectumRx.Api.Integration.Handlers;
global using ParusRx.Services.DirectumRx.Api.Services;
global using Serilog.Context;
