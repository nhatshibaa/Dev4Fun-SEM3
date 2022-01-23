<template>
  <div class='card p-4 rounded-plus bg-faded'>
    <!--                  @if(\Illuminate\Support\Facades\Session::has('message'))-->
    <!--                  <div class="alert alert-{{\Illuminate\Support\Facades\Session::get('style')}}" role="alert">-->
    <!--                    {!! \Illuminate\Support\Facades\Session::get('message') !!}-->
    <!--                  </div>-->
    <!--                  @endif-->
    <div v-if='messenger'>
      <div :class="'alert alert-'+typeMessenger" role='alert'>
        {{ messenger }}
      </div>
    </div>

    <form @submit.prevent='onUpdate()'>
      <div class='form-group'>
        <label class='form-label' for='password'>Password</label>
        <input type='password' v-model='user.password' name='Password' id='password'
               class='form-control form-control-lg' placeholder='password' required>
        <div class='invalid-feedback'>Sorry, you missed this one.</div>
        <div class='help-block'>Your password</div>
      </div>
      <div class='form-group'>
        <label class='form-label' for='new-password'>New Password</label>
        <input type='password' v-model='user.new_password' name='Password' id='new-password'
               class='form-control form-control-lg' placeholder='new - password' required>
        <div class='invalid-feedback'>Sorry, you missed this one.</div>
        <div class='help-block'>Your new password</div>
      </div>
      <div class='row no-gutters'>
        <div class='col-lg-6 pr-lg-1 my-2'>
          <button type='submit' class='btn btn-info btn-block btn-lg'>Sign in with <i class='fab fa-google'></i>
          </button>
        </div>
        <div class='col-lg-6 pl-lg-1 my-2'>
          <button id="'js-login-btn" type='submit' class='btn btn-danger btn-block btn-lg'>Secure login</button>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
// {{$route.params.mail}}
export default {
  //       asyncData({app}) {
  //   console.log('ok1');
  //   const uri = 'http://localhost:8000/api/account/new-password/' + this.$route.params.mail;
  //   const checkMail = this.$axios.get(uri);
  //   switch (checkMail){
  //     case 1:
  //       this.messenger = 'Email không hợp lệ!!'
  //       this.typeMessenger = 'danger'
  //       break;
  //     default:
  //       this.messenger = 'Hệ thống lỗi!!!'
  //       this.typeMessenger = 'danger'
  //       break;
  //   }
  //   console.log('ok2');
  // },

  layout: 'account-form-layout',
  data() {
    return {
      user: {
        password: '',
        new_password: ''
      },
      checkLogin: 0,
      messenger: '',
      typeMessenger: ''
    }
  },
  async fetch() {
    const uri = '/account/new-password/' + this.$route.params.mail
    const mailCheck = await this.$axios.$get(uri)
    switch (mailCheck) {
      case 1:
        this.messenger = 'Hệ thống đã gửi mật khẩu mới đến mail của bạn vui lòng kiểm tra !'
        this.typeMessenger = 'success'
        break
      case 2:
        this.messenger = 'Email không hợp lệ'
        this.typeMessenger = 'danger'
        break
      default:
        this.messenger = 'Hệ thống lỗi!!!'
        this.typeMessenger = 'danger'
        break
    }
  },
  methods: {
    async onUpdate() {
      const uri = '/account/reset-password/' + this.$route.params.mail
      this.checking = await this.$axios.post(uri, this.user)
      switch (this.checking.data) {
        case 1:
          this.messenger = 'Đổi mật khẩu thành công'
          this.typeMessenger = 'success'
          break
        case 2:
          this.messenger = 'Sai mật khẩu vui lòng nhập lại'
          this.typeMessenger = 'danger'
          break
        default:
          this.messenger = 'Hệ thống lỗi!!!'
          this.typeMessenger = 'danger'
          break
      }
    }
  }
}
</script>

