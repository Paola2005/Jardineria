using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;
using Persistence.Data;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly JardineriaContext _context;

    private ICity _city;
    private IClient _client;
    private ICountry _country;
    private IEmployee _employee;
    private IOffice _office;
    private IPayment _payment;
    private IPerson _person;
    private IProduct _product;
    private IState _state;
    private IStatus _status;
    private ISupplier _supplier;
    private IMethodPayment _method;
    private IOrderDetail _detailorder;
    private IOrder _order;
    private IPersonType _personTy;
    private IProductLine _produLine;
    private IPostalCode _postal;
    public ICity Cities {
        get
        {
            if (_city == null)
            {
                _city = new CityRepository(_context);
            }
            return _city;
        }
    }

    public IClient Clients {
        get
        {
            if (_client == null)
            {
                _client = new ClientRepository(_context);
            }
            return _client;
        }
    }

    public ICountry Countries {
        get
        {
            if (_country == null)
            {
                _country = new CountryRepository(_context);
            }
            return _country;
        }
    }

    public IEmployee Employees {
        get
        {
            if (_employee == null)
            {
                _employee = new EmployeeRepository(_context);
            }
            return _employee;
        }
    }

    public IMethodPayment Methods {
        get
        {
            if (_method == null)
            {
                _method = new MethodPaymentRepository(_context);
            }
            return _method;
        }
    }

    public IOffice Offices {
        get
        {
            if (_office == null)
            {
                _office = new OfficeRepository(_context);
            }
            return _office;
        }
    }

    public IOrderDetail Details {
        get
        {
            if (_detailorder == null)
            {
                _detailorder = new OrderDetailRepository(_context);
            }
            return _detailorder;
        }
    }

    public IOrder Orderse {
        get
        {
            if (_order == null)
            {
                _order = new OrderRepository(_context);
            }
            return _order;
        }
    }

    public IPayment Payments {
        get
        {
            if (_payment == null)
            {
                _payment = new PaymentRepository(_context);
            }
            return _payment;
        }
    }

    public IPersonType PTypes {
        get
        {
            if (_personTy == null)
            {
                _personTy = new PersonTypeRepository(_context);
            }
            return _personTy;
        }
    }

    public IPerson Persons {
        get
        {
            if (_person == null)
            {
                _person = new PersonRepository(_context);
            }
            return _person;
        }
    }

    public IPostalCode PCodes {
        get
        {
            if (_postal == null)
            {
                _postal = new PostalCodeRepository(_context);
            }
            return _postal;
        }
    }

    public IProductLine PLines {
        get
        {
            if (_produLine == null)
            {
                _produLine = new ProductLineRepository(_context);
            }
            return _produLine;
        }
    }

    public IProduct Products {
        get
        {
            if (_product == null)
            {
                _product = new ProductRepository(_context);
            }
            return _product;
        }
    }

    public IState States {
        get
        {
            if (_state == null)
            {
                _state = new StateRepository(_context);
            }
            return _state;
        }
    }

    public IStatus Status {
        get
        {
            if (_status == null)
            {
                _status = new StatusRepository(_context);
            }
            return _status;
        }
    }

    public ISupplier Suppliers {
        get
        {
            if (_supplier == null)
            {
                _supplier = new SupplierRepository(_context);
            }
            return _supplier;
        }
    }

    public UnitOfWork(JardineriaContext context)
    {
        _context = context;
    }
    


    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

