<template>
    <div class="row m-0" style="background-color:#f3f3f5">
    <div class="col-sm"></div>
    <div class="col-sm " >
      <div class="spacing-top"></div>
       <div class="border border-3 padding-login rounded" style="background-color: #fff;">
        <div class="h3">Đăng nhập</div>
        <a-form
      :model="formState"
      name="normal_login"
      class="login-form"
      @finish="onFinish"
      @finishFailed="onFinishFailed"
    >
      <a-form-item
        label="Username"
        name="username"
        :rules="[{ required: true, message: 'Please input your username!' }]"
      >
        <a-input v-model:value="formState.username" class="my-3">
          <template #prefix>
            <UserOutlined class="site-form-item-icon" />
          </template>
        </a-input>
      </a-form-item>

      <a-form-item
        label="Password"
        name="password"
        :rules="[{ required: true, message: 'Please input your password!' }]"
      >
        <a-input-password v-model:value="formState.password" class="my-3">
          <template #prefix>
            <LockOutlined class="site-form-item-icon" />
          </template>
        </a-input-password>
      </a-form-item>

      <a-form-item>
        <a-form-item name="remember" no-style>
          <a-checkbox v-model:checked="formState.remember">Remember me</a-checkbox>
        </a-form-item>
        <a class="login-form-forgot" href="">Forgot password</a>
      </a-form-item>

      <a-form-item>
        <a-button :disabled="disabled" type="primary" html-type="submit" class="login-form-button w-100 my-3">
          Log in
        </a-button>
        Or
        <router-link :to="{name :'RegisterUser'}">
          Đăng ký
        </router-link>
      </a-form-item>
    </a-form>
       </div>
    <div class="spacing-bottom"></div>

    </div>
    <div class="col-sm"></div>
  </div>

  </template>
  <script>
  import { defineComponent, reactive, computed } from 'vue';
  import { UserOutlined, LockOutlined } from '@ant-design/icons-vue';
  export default defineComponent({
    components: {
      UserOutlined,
      LockOutlined,
    },
    setup() {
      const formState = reactive({
        username: '',
        password: '',
        remember: true,
      });
      const onFinish = values => {
        console.log('Success:', values);
      };
      const onFinishFailed = errorInfo => {
        console.log('Failed:', errorInfo);
      };
      const disabled = computed(() => {
        return !(formState.username && formState.password);
      });
      return {
        formState,
        onFinish,
        onFinishFailed,
        disabled,
      };
    },
  });
  </script>
  <style scoped>
  .spacing-top{
    margin-top:  100px;
  }
  .padding-login{
    padding: 48px;
  }
  .spacing-bottom{
    margin-bottom:  400px;
  }
  #components-form-demo-normal-login .login-form {
    max-width: 300px;
  }
  #components-form-demo-normal-login .login-form-forgot {
    float: right;
  }
  #components-form-demo-normal-login .login-form-button {
    width: 100%;
  }
  </style>
