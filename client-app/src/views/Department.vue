<template>    
     <div class="container">
       
      <div v-show="error" class="alert alert-danger">{{ error }}</div>

      <b-form @submit="createDepartment">
        <b-form-group
          id="input-group-1"
          label="Name:"
          label-for="input-1"
        >
          <b-form-input
            id="input-1"
            v-model="department.name"
            type="text"
            placeholder="Enter Department Name"
            maxlength="200"
            required          
          ></b-form-input>
        </b-form-group>

      <b-button type="submit" variant="primary">Submit</b-button>
    </b-form>
  </div>
</template>

<script>
  import axios from 'axios'

  export default {
    data() {
      return {
        error: '',
        department: {}
      }
    },  
    methods: {    
      async createDepartment(e) {
        e.preventDefault()

        await axios({
            url: "/api/departments",
            method: "post",
            headers: { "content-type": "application/json" },
            data: JSON.stringify(this.department)
        })
        .then(() => this.$router.push({ path: '/' }))
        .catch((error) => {
          if(error.response.data.error){
            this.error = error.response.data.error
          }
        })
      }
    }
  }
</script>
