using System;
using System.Collections.Generic;

///
namespace PizzaBox.Domain.Interfaces
{
  /// Use C.R.U.D.
  public interface IRepository<T> where T : class
  {
    /// Create.
    public bool Insert(T item);

    /// Read.
    public IEnumerable<T> Select(Func<T, bool> filter);

    /// Update.
    public T Update(T item);

    /// Delete.
    public bool Delete(T item);
  }// /ifc 'IRepository'
}// /ns '..Interfaces'
 // EoF