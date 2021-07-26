<template>
  <section class="container">  

    <div v-show="error" class="alert alert-danger">{{ error }}</div>

    <p>
      <router-link class="btn btn-link" :to="{name: 'department'}">Create new Department</router-link>
    </p>
    <div class="col-md-6">
      <div class="accordion" role="tablist" v-if="departments.length">

          <b-card no-body class="mb-1" 
          v-for="department in departments" 
          :key="department.id">
          
            <b-card-header header-tag="header" class="p-1" role="tab">
              <b-button block 
              v-b-toggle="`accordion-${department.id}`" 
              variant="primary">
                {{department.name}} 
                <b-badge variant="light">
                  {{averageSalary(department.employees)}}
                </b-badge>                       
              </b-button>
            </b-card-header>  

            <b-collapse visible
            :id="`accordion-${department.id}`" 
            accordion="my-accordion" 
            role="tabpanel"
            class="accordion-body">
                <div class="department-settings">
                    <DepartmentSettings :departmentId="department.id"/>
                </div>
              <router-link class="btn btn-link" :to="{name: 'employee'}">Create new Employee</router-link>
              <b-card-body 
              v-for="employee in department.employees" 
              :key="employee.id">                              
                <b-card-text>{{employee.firstName}} {{employee.lastName}}</b-card-text>
               
                <b-card-text><b>Salary:</b> {{employee.salary}}</b-card-text>
                <b-card-text>
                  <router-link class="btn btn-warning" :to="{name: 'editEmployee', params: {id: employee.id}}">Edit</router-link> 
                  | <a class="btn btn-danger" v-on:click="deleteEmployee(employee.id)">Delete</a> 
                </b-card-text>
              </b-card-body>              
            </b-collapse>

          </b-card>
          
          <router-view></router-view>
        </div>
    </div>
  </section>
</template>

<script>
// @ is an alias to /src
import { mapState, mapActions, mapMutations } from 'vuex'
import axios from 'axios'
import DepartmentSettings from '@/components/DepartmentSettings.vue'

export default {
  name: 'Home',
  components: {
    DepartmentSettings
  },
  data(){
    return{
      error: ''
    }
  },
  computed: {
    ...mapState([
        'departments'
    ])    
  },
  created () {
      this.getDepartments()
  },
  methods:{
    ...mapActions([
        'getDepartments',
    ]),
    averageSalary: (employees) => {
      let avg = employees.reduce((prev, current) => prev + current.salary, 0) / employees.length;
      return avg ? Math.round(avg) : 0
    },
    async deleteEmployee(employeeId){      
      await axios({
          url: "/api/employees/" + employeeId,          
          method: "delete"
      })
      .then(() => this.getDepartments())
      .catch((error) => this.error = error.message)
    }
  }
}
</script>
<style scoped>
    .department-settings{
        padding: 5px;
    }
    .accordion-body{
      min-height: 130px;
    }
</style>