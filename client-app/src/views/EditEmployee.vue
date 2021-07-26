<template>
     <div class="container">
       
    <div v-show="error" class="alert alert-danger">{{ error }}</div>

    <b-form @submit="editEmployee">
      <b-form-group
        id="input-group-1"
        label="FirstName:"
        label-for="input-1"
      >
        <b-form-input
          id="input-1"
          v-model="employee.firstName"
          type="text"
          placeholder="Enter First Name"
          maxlength="200"
          required          
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-2" label="LastName:" label-for="input-2">
        <b-form-input
          id="input-2"
          v-model="employee.lastName"
          type="text"          
          placeholder="Enter Last Name"
          maxlength="200"
          required
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-3" label="Salary:" label-for="input-3">
        <b-form-input
          id="input-3"
          v-model.number="employee.salary"
          placeholder="Enter Salary"
          type="number"
          required
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-4" label="Department:" label-for="input-4">
        <b-form-select
          id="input-4"
          v-model="employee.department.id"
          :options="getDepNames"
          required
        ></b-form-select>
      </b-form-group>

      <b-button type="submit" variant="primary">Submit</b-button>
    </b-form>    
  </div>
</template>

<script>
  
  import { mapActions, mapState } from 'vuex'
  import axios from 'axios'

  export default {
    data(){
      return{
        error: ''
      }
    },
    created(){
        this.getEmployee(this.$route.params.id)
        this.getDepartments()
    },
    computed:{
      ...mapState([
          'employee',
          'departments'
      ]),
      getDepNames: function(){
          return this.departments.map(x => {
            return {
              text: x.name, 
              value: x.id
            }
          });
      },
    },   
    methods: {
      ...mapActions([
        'getEmployee',
        'getDepartments'
      ]),      
      async editEmployee(e) {
        e.preventDefault()

        await axios({
            url: "/api/employees",
            method: "put",
            headers: { "content-type": "application/json" },
            data: JSON.stringify(this.employee)
        })
        .then(() => this.$router.push({ path: '/' }))
        .catch((error) => this.error = error.message)
      }
    }
  }
</script>
