  
<template>
 <div>
    <b-dropdown variant="light">
      <template #button-content>
        <b-icon icon="gear-fill" aria-hidden="true"></b-icon>        
      </template>
      <b-dropdown-item-button variant="warning">
        <router-link :to="{name: 'editDepartment', params: {id: departmentId}}">
          <b-icon icon="pencil" aria-hidden="true"></b-icon>
          Edit</router-link>
          </b-dropdown-item-button>
      <b-dropdown-item-button variant="danger" @click="deleteDepartment()">
        <b-icon icon="trash-fill" aria-hidden="true"></b-icon>
        Delete
      </b-dropdown-item-button>
    </b-dropdown>
  </div>
</template>
<script>
import axios from 'axios'
import {mapActions} from 'vuex'

export default ({
  props: ['departmentId'],  
  methods: {
    ...mapActions([
      'getDepartments'
    ]),
    async deleteDepartment(){
      await axios({
          url: "/api/departments/" + this.departmentId,          
          method: "delete"
      }).then(() => this.getDepartments())
      .catch((error) => this.error = "Error occured. Try again")
    }
  }
})
</script>

<style scoped>

</style>