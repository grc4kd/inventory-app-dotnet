using NUnit.Framework;
using api;
using System.Linq;
using System;

namespace test;

public class StoresRequestTests
{
    private StoresRequest? _request;
    private readonly StoresRequest defaultRequest = new(0, 0, 0);

    [Test]
    public void StoresRequest_FieldSpecsAndDefaults()
    {
        _request = defaultRequest;

        StoresRequest request = new(0, 0, 0);
        
        Assert.AreEqual(_request, request);
    }
}
