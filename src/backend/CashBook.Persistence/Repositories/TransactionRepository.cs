using CashBook.Domain.Entities;
using CashBook.Domain.Entities.Transactions;
using CashBook.Persistence.DataContexts;
using CashBook.Persistence.Repositories.Interfaces;

namespace CashBook.Persistence.Repositories;

public class TransactionRepository(AppDbContext context) 
    : EntityRepositoryBase<AppDbContext, Transaction>(context),
    ITransactionRepository
{
    
}