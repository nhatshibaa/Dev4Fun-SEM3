<template>
  <div>
    <div class="page-wrapper auth">
      <div class="page-inner bg-brand-gradient">
        <div class="page-content-wrapper bg-transparent m-0">
          <div class="height-10 w-100 shadow-lg px-4 bg-brand-gradient">
            <div class="d-flex align-items-center container p-0">
              <div class="page-logo width-mobile-auto m-0 align-items-center justify-content-center p-0 bg-transparent bg-img-none shadow-0 height-9 border-0">
                <a href="javascript:void(0)" class="page-logo-link press-scale-down d-flex align-items-center">
                  <img src="/img/logo.png" alt="SmartAdmin WebApp" aria-roledescription="logo">
                  <span class="page-logo-text mr-1">SmartAdmin WebApp</span>
                </a>
              </div>
              <nuxt-link to='/account/register' v-if='!register' class="btn-link text-white ml-auto">
                Create Account
              </nuxt-link>
              <nuxt-link to='/account/login' v-if='register' class="btn-link text-white ml-auto">
                Login
              </nuxt-link>

            </div>
          </div>
          <div class="flex-1" style="background: url('/img/svg/pattern-1.svg') no-repeat center bottom fixed; background-size: cover;">
            <div class="container py-4 py-lg-5 my-lg-5 px-4 px-sm-0">
              <div class="row">
                <div class="col col-md-6 col-lg-7 hidden-sm-down">
                  <h2 class="fs-xxl fw-500 mt-4 text-white">
                    The simplest UI toolkit for developers &amp; programmers
                    <small class="h3 fw-300 mt-3 mb-5 text-white opacity-60">
                      Presenting you with the next level of innovative UX design and engineering. The most modular toolkit available with over 600+ layout permutations. Experience the simplicity of SmartAdmin, everywhere you go!
                    </small>
                  </h2>
                  <a href="#" class="fs-lg fw-500 text-white opacity-70">Learn more &gt;&gt;</a>
                  <div class="d-sm-flex flex-column align-items-center justify-content-center d-md-block">
                    <div class="px-0 py-1 mt-5 text-white fs-nano opacity-50">
                      Find us on social media
                    </div>
                    <div class="d-flex flex-row opacity-70">
                      <a href="#" class="mr-2 fs-xxl text-white">
                        <i class="fab fa-facebook-square"></i>
                      </a>
                      <a href="#" class="mr-2 fs-xxl text-white">
                        <i class="fab fa-twitter-square"></i>
                      </a>
                      <a href="#" class="mr-2 fs-xxl text-white">
                        <i class="fab fa-google-plus-square"></i>
                      </a>
                      <a href="#" class="mr-2 fs-xxl text-white">
                        <i class="fab fa-linkedin"></i>
                      </a>
                    </div>
                  </div>
                </div>
                <div class="col-sm-12 col-md-6 col-lg-5 col-xl-4 ml-auto">
                  <h1 class="text-white fw-300 mb-3 d-sm-block d-md-none">
                    Secure login
                  </h1>
                  <nuxt/>
                </div>
              </div>
              <div class="position-absolute pos-bottom pos-left pos-right p-3 text-center text-white">
                2020 © SmartAdmin by&nbsp;<a href='https://www.gotbootstrap.com' class='text-white opacity-40 fw-500' title='gotbootstrap.com' target='_blank'>gotbootstrap.com</a>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'account-form-layout',
  data(){
    return {
        register: false,
    }
  },
  head() {
    return {
      link: [
        { rel: 'stylesheet', href: '/css/vendors.bundle.css' },
        { rel: 'stylesheet', href: '/css/app.bundle.css' },
        { rel: 'stylesheet', href: '/css/skins/skin-master.css' },
        { rel: 'stylesheet', href: '/css/datagrid/datatables/datatables.bundle.css' },
        { rel: 'stylesheet', href: '/css/fa-brands.css' },
      ],
      script: [
        { hid: 'stripe', src: '/js/datagrid/datatables/datatables.bundle.js', defer: true },
        { hid: 'stripe', src: '/js/vendors.bundle.js', defer: true },
        { hid: 'stripe', src: '/js/app.bundle.js', defer: true }
      ]
    }
  }

}
</script>
