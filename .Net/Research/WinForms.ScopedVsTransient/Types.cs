﻿namespace WinForms.ScopedVsTransient;

internal interface IService
{
    string GetInfo();
}

internal interface IScopedService : IService
{
}

internal interface ITransientService : IService
{
}

internal class Service : IScopedService, ITransientService
{
    private readonly Guid _guid;

    public Service()
    {
        _guid = Guid.NewGuid();
    }

    public string GetInfo()
    {
        return _guid.ToString();
    }
}

internal class Client
{
    private readonly IScopedService _scoped;
    private readonly ITransientService _transient;

    public Client(IScopedService scoped, ITransientService transient)
    {
        _scoped = scoped;
        _transient = transient;
    }

    public void PrintServicesInfo(Label scoped, Label transient)
    {
        scoped.Text = $"Scoped : {_scoped.GetInfo()}";
        transient.Text = $"Transient : {_transient.GetInfo()}";
    }
}
