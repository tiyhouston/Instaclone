using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

public interface HasId {
    int Id { get; set; }
}

public interface IGramRepo {
    void Add(Gram g);
    IEnumerable<Gram> ReadAll();
    Gram Read(int id);
    bool Update(int id);
    Gram Delete(int id);
}

public class GramRepo : IGramRepo {

    private List<GramRepo> grams = new List<GramRepo>();

    public GramRepo g;

    public void Add(Gram g) {
        grams.Add(p);
    }

    public IEnumerable<Gram> ReadAll() {
        return grams.ToList();
    }

    public Gram Read(int id){
        return grams.First(x => x.Id == id);
    }

    public bool Update(Gram g) {
        Gram actual = grams.First(x => x.Id == g.Id);
        if(actual != null) {
            grams.Remove(g);
            g.Id = g.Id;
            grams.Add(g);
            return true;
        }
        return false;
    }

    public Gram Delete(int id) {
        Gram p = grams.First(x => x.Id == id);
        if(g != null) {
            grams.Remove(g);
            return g;
        }
        return null;
    }
}