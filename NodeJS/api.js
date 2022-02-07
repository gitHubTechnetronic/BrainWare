var  Db = require('./dboperations');
var  Order = require('./order');
var  express = require('express');
var  bodyParser = require('body-parser');
var  cors = require('cors');
var  app = express();
var  router = express.Router();

app.use(bodyParser.urlencoded({ extended:  true }));
app.use(bodyParser.json());
app.use(cors());
app.use('/api', router);

router.use((request, response, next) => {
    //console.log('middleware');
    next();
  });

    
  router.route('/company/:id').get((request, response) => {
    Db.getCompany(request.params.id).then((data) => {
      response.json(data[0]);
    })
  })

  router.route('/orders/:id').get((request, response) => {
    Db.getOrders(request.params.id).then((data) => {
      response.json(data[0]);
    })
  }) 

  router.route('/orderproducts/:id').get((request, response) => {
    Db.getOrderProducts(request.params.id).then((data) => {
      response.json(data[0]);
    })
  })

  router.route('/companyorders/:id').get((request, response) => {
    Db.getCompanyOrders(request.params.id).then((data) => {
      response.send(JSON.stringify(data[0])); 
    })
  }) 

  var  port = process.env.PORT || 8090;
  app.listen(port);
  console.log('Order API is runnning at ' + port);
