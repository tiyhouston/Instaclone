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

public interface IRepository<T> where T : class, HasId {
    void Add(T item);
    IEnumerable<T> ReadAll();
    T Read(int id);
    bool Update(T item);
    T Delete(int id);
}

public class GramRepo<T> : IRepository<T> where T : class, HasId {
    private DB db;
    private DbSet<T> table;
   // private GramRepo<T> 
    public GramRepo(DB db){
        this.db = db;
    }
    public GramRepo(DB db, string tableName) {
        this.db = db;
        table = GetTable(tableName);
    }

    private DbSet<T> GetTable(string tableName){
        return (DbSet<T>)db.GetType().GetProperty(tableName).GetValue(db);
    }

    public static void Register(IServiceCollection services, string n) {
        services.AddScoped<IRepository<T>>(provider => {
            var db = provider.GetRequiredService<DB>();
            return new GramRepo<T>(db, n);
        });
    }
    public void Add(T item) {
        table.Add(item);
    }

    public IEnumerable<T> ReadAll() {
        return table.ToList();
    }

    public T Read(int id){
        return table.First(x => x.Id == id);
    }

    public bool Update(T item) {
        T actual = table.First(x => x.Id == item.Id);
        if(actual != null) {
            table.Remove(item);
            item.Id = actual.Id;
            table.Add(item);
            return true;
        }
        return false;
    }

    public T Delete(int id) {
        T actual = table.First(x => x.Id == id);
        if(actual != null) {
            table.Remove(actual);
            db.SaveChanges();
            return actual;
        }
        return null;
    }
}