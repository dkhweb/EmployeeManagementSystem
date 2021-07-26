<template>
     <div class="container">
    <b-form @submit="editDepartment">
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
    import {mapActions, mapState} from 'vuex'
    import axios from 'axios'

  export default {
    data(){
      return{
        error: ''
      }
    },
    created(){
        this.getDepartment(this.$route.params.id)
    },
    computed: {
        ...mapState([
            'department'
        ])
    },
    methods: {    
        ...mapActions([
            'getDepartment'
        ]),
        async editDepartment(e) {
            e.preventDefault()

            await axios({
                url: "/api/departments",
                method: "put",
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
