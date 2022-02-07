var  config = require('./node_modules/dbconfig');
const  sql = require('mssql');
  
async  function  getCompany(companyId) {
    try {
      let  pool = await  sql.connect(config);

      let  product = await  pool.request()
    .input('Id', sql.Int, companyId)   
    .execute('proc_CompanyFetch');

      return  product.recordsets;
    }
    catch (error) {
      console.log(error);
    }
  }

  
async  function  getOrders(companyId) {
    try {
      let  pool = await  sql.connect(config);
      

    let  company = await  pool.request()
    .input('Id', sql.Int, companyId)   
    .execute('proc_CompanyOrders');

      let  product = await  pool.request()
    .input('Id', sql.Int, companyId)   
    .execute('proc_CompanyOrders');

      return  product.recordsets;
    }
    catch (error) {
      console.log(error);
    }
  }

  
  async  function  getOrderProducts(companyId) {
    try {
      let  pool = await  sql.connect(config);
      
      let  product = await  pool.request()
    .input('Id', sql.Int, companyId)   
    .execute('proc_OrderProducts');


      return  product.recordsets;
    }
    catch (error) {
      console.log(error);
    }
  }
  
  async  function  getCompanyOrders(companyId) {
    try {

        var arrdata = new Array();
                
        var arrdataCompany = new Array();        
        var arrdataOrders = new Array();
        var arrdataOrderProducts = new Array();

        var promises = []; 

        promises.push(getCompany(companyId).then((data) => {   
            
          if(data[0][0] === undefined)
          { 
            var json_company = {"Company":[{"CompanyId":0,"CompanyName":"","isinDatabase":false,"ErrorMessage":"No Data"}]};
              
            json_company = JSON.stringify(json_company); 

            arrdataCompany.push(JSON.parse(json_company));

          }
          else
          {
            data[0][0].CompanyName = data[0][0].CompanyName.trim();
            data[0][0].isinDatabase = true;
            data[0][0].ErrorMessage = null;

            arrdataCompany.push({"Company": data[0]});
            
          }
        }));


    promises.push(getOrders(companyId).then((data) => {
        arrdataOrders.push({"Orders": data[0]});
          }            
    ));

    promises.push(getOrderProducts(companyId).then((data) => {
        arrdataOrderProducts.push({"orderProducts": data[0]});
          }            
    ));

    var json_data = [];
    
    await Promise.all(promises).then(function() {

        if(!arrdataCompany[0].Company[0].isinDatabase)
        {
                
          var json_company = JSON.stringify(arrdataCompany[0]).replace(/]|[[]/g, ''); 

          arrdataCompany = JSON.parse(json_company);
              
          arrdata.push(arrdataCompany);

          json_data = arrdata; 

          return json_data; 
        }
        else
        {
                
          var json_company = JSON.stringify(arrdataCompany[0]).replace(/]|[[]/g, ''); 

          arrdataCompany = JSON.parse(json_company);
          
        }

    arrdataOrders[0].Orders.forEach(x => {
      x.OrderTotal = 0;
        x.OrderProducts = [];
        
        arrdataOrderProducts[0].orderProducts.forEach(j => { 
            if (j.order_id == x.order_id) {

                x.OrderTotal = x.OrderTotal + (j.Price * j.Quantity);
                j.Product = {"Name": j.Name}; 

                x.OrderProducts.push(j);

            }
        });

    });

    var json_orders = JSON.stringify(arrdataOrders[0], null, '\t');

    arrdataOrders = JSON.parse(json_orders);

    arrdataCompany.Orders = arrdataOrders.Orders;
    
      arrdata.push(arrdataCompany);

        json_data = arrdata; 


    }, function(err) {
        // error occurred...
        console.log(err);
    });

      return json_data; 

    }
    catch (error) {
      console.log(error);
    }
  }

  module.exports = {
    getCompany: getCompany,
    getOrders:  getOrders,
    getOrderProducts: getOrderProducts,
    getCompanyOrders:  getCompanyOrders
  }