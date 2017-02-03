using MmsApi.Models;
using MmsDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MmsApi.Controllers
{
    public class HomeController
    {
    }
}
public class HomeController<E> : ApiController where E : class
{
    private Repository<E> repository;
    private ModelFactory modelFactory;
    private EntityParser entityParser;

    public HomeController(Repository<E> _repo)
    {
        repository = _repo;
    }
    protected Repository<E> Repository
    {
        get { return repository; }
    }


    protected ModelFactory Factory
    {
        get
        {
            if (modelFactory == null) modelFactory = new ModelFactory();
            return modelFactory;
        }
    }

    protected EntityParser Parser
    {
        get
        {
            if (entityParser == null) entityParser = new EntityParser();
            return entityParser;
        }
    }
}
