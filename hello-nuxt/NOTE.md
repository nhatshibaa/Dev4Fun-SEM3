Stop the Node.js server.

`npm install cors --save`


Add following lines to your server.js or index.js

var cors = require('cors')

app.use(cors()) // Use this after the variable declaration


thêm vào `nuxt.config.js`
auth: {
redirect: {
callback:'/welcome' //sau khi login sẽ chuyển hướng về đây
},
strategies: {
local: {
endpoints: {
// các đường dẫn đến API
// propertyName: kết quả từ API trả về, nhớ xem kết quả để đặt key cho đúng
login: { url: '/login', method: 'post', propertyName: 'meta.token' },
// sau khi login, sẽ tự động chạy cái API này nữa để lấy dữ liệu user
user: { url: '/user', method: 'post', propertyName: 'data' },
logout: false
}
},
}
},
//dùng cái này để sử dụng middleware xác thực người dùng cho mọi route, tương tự middleware trong Laravel
router: {
middleware: ['auth']
},
