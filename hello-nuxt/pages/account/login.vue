<template>
  <div class="main">
    <input type="checkbox" id="chk" aria-hidden="true">

    <div class="signup">
      <form @submit.prevent='onRegister()' method="post">
        <label for="chk" aria-hidden="true">Sign up</label>
        <input type="text" name="fullname" placeholder="Full name" required="">
        <input type="email" name="email" placeholder="Email" required="">
        <input type="password" name="password" placeholder="Password" required="">
        <input type="text" name="address" placeholder="Address" required="">
        <input type="number" name="phoneNum" placeholder="Phone number" required="">
        <input type="number" name="gender" placeholder="Gender" required="">
        <button>Sign up</button>
      </form>
    </div>
    <div class="login">
      <form  @submit.prevent='onLogin()' >
        <label for="chk" aria-hidden="true">Login</label>
        <input type="email" name="Email" placeholder="Email" required="">
        <input type="password" name="Password" placeholder="Password" required="">
        <button>Login</button>
      </form>
    </div>
  </div>
</template>

<style>
body{
  margin: 0;
  padding: 0;
  display: flex;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
  font-family: 'Jost', sans-serif;
  background: linear-gradient(to bottom, #0f0c29, #302b63, #24243e);
}
.main{
  width: 550px;
  height: 700px;
  overflow: hidden;
  background: url("https://doc-08-2c-docs.googleusercontent.com/docs/securesc/68c90smiglihng9534mvqmq1946dmis5/fo0picsp1nhiucmc0l25s29respgpr4j/1631524275000/03522360960922298374/03522360960922298374/1Sx0jhdpEpnNIydS4rnN4kHSJtU1EyWka?e=view&authuser=0&nonce=gcrocepgbb17m&user=03522360960922298374&hash=tfhgbs86ka6divo3llbvp93mg4csvb38") no-repeat center/ cover;
  border-radius: 10px;
  box-shadow: 5px 20px 50px #000;
}
#chk{
  display: none;
}
.signup{
  position: relative;
  width:100%;
  height: 100%;
}
label{
  color: #fff;
  font-size: 2.3em;
  justify-content: center;
  display: flex;
  margin: 60px;
  font-weight: bold;
  cursor: pointer;
  transition: .5s ease-in-out;
}
input{
  width: 60%;
  height: 20px;
  background: #e0dede;
  justify-content: center;
  display: flex;
  margin: 20px auto;
  padding: 10px;
  border: none;
  outline: none;
  border-radius: 5px;
}
button{
  width: 60%;
  height: 40px;
  margin: 10px auto;
  justify-content: center;
  display: block;
  color: #fff;
  background: #573b8a;
  font-size: 1em;
  font-weight: bold;
  margin-top: 20px;
  outline: none;
  border: none;
  border-radius: 5px;
  transition: .2s ease-in;
  cursor: pointer;
}
button:hover{
  background: #6d44b8;
}
.login{
  height: 660px;
  background: #eee;
  border-radius: 60% / 10%;
  transform: translateY(-180px);
  transition: .8s ease-in-out;
}
.login label{
  color: #573b8a;
  transform: scale(.6);
}

#chk:checked ~ .login{
  transform: translateY(-700px);
}
#chk:checked ~ .login label{
  transform: scale(1);
}
#chk:checked ~ .signup label{
  transform: scale(.6);
}
</style>

<script>
export default {
  layout: 'null-layout',
  data() {
    return {
      user: {
        Email: '',
        Password: ''
      },
      messenger:'',
      typeMessenger:'',
    }
  },
  methods: {
     onLogin() {
      alert('Đăng nhập thành công')

      try {
         console.log(this.$auth.loggedIn);
         const response = await this.$auth.loginWith('local', {data: this.user})
         console.log(response)
         switch (response.data) {
           case 1:
             alert('Đăng nhập thành công')
             this.messenger = 'OK!';
             this.typeMessenger = 'success';
               await this.$router.push('/account');
             break;
           case 2:
             this.messenger = 'Bạn đang đăng nhập trên thiết bị khác';
             this.typeMessenger = 'danger';
             break;
           case 3:
             this.messenger = 'Sai tài khoản hoặc mật khẩu';
             this.typeMessenger = 'danger';
             break;
           default:
             this.messenger = 'Hệ thống lỗi!!!';
             this.typeMessenger = 'danger';
             break;
         }
       } catch (err) {
         console.log(err)
       }
    },
    onRegister() {
       const uri = '/account/register'
       this.$axios.post(uri, this.user).then((response) => {
         switch (response.data) {
           case 1:
             this.messenger = 'Account created successfully<br/> <strong>Please check your email to receive the password</strong>'
             this.typeMessenger = 'success'
             alert('Đăng kí thành công')
             // this.$router.push('/account/login')
             break;
           case 2:
             this.messenger = 'Invalid email try another email'
             this.typeMessenger = 'danger'
             break;
           default:
             this.messenger = 'Hệ thống lỗi!!!'
             this.typeMessenger = 'danger'
             break;
         }
       })
    }
  }
}

</script>

