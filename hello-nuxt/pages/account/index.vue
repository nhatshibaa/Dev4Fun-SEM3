<template>
  <main id="js-page-content" role="main" class="page-content">
    <ol class="breadcrumb page-breadcrumb">
      <li class="breadcrumb-item"><a href="javascript:void(0);">SmartAdmin</a></li>
      <li class="breadcrumb-item">Datatables</li>
      <li class="breadcrumb-item active">Basic</li>
      <li class="position-absolute pos-top pos-right d-none d-sm-block"><span class="js-get-date"></span></li>
    </ol>
    <div class="row">
      <div class="col-xl-12">
        <div id="panel-1" class="panel">
          <div class="panel-hdr">
            <h2>
              News <span class="fw-300"><i>Account Table</i></span>
            </h2>
          </div>
          <div class="panel-container show">
            <div class="panel-content">
              <!-- datatable start -->
              <table id="dt-basic-example" class="table table-bordered table-hover table-striped w-100"
                     v-if="ListAccount">
                <thead>
                <tr>
                  <th>Full Name</th>
                  <th>Username</th>
                  <th>Email</th>
                  <th>Status</th>
                  <th>Action</th>
                </tr>
                </thead>
                <tbody v-for="(account,index) in ListAccount.data" :key="index">
                <tr>
                  <td>{{ account.FullName}}</td>
                  <td>{{ account.UserName}}</td>
                  <td>{{ account.email}}</td>
                  <td style="color: green" v-if='account.Status===1'>Online</td>
                  <td style="color: red" v-if='account.Status===0'>Offline</td>
                  <td>
                    <nuxt-link :to="'/reset-password/'+account.email">
                      Reset Password
                    </nuxt-link>
                  </td>
                </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
    </div>
  </main>
</template>

<script>
export default {
  async asyncData({app,redirect}) {
    if (!app.$auth.loggedIn) {
      return redirect('/account/login')
    }
    const ListAccount = await app.$axios.$get('/account/data');
    return {ListAccount};
  },
}

</script>
