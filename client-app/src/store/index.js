import Vue from 'vue'
import Vuex from 'vuex'

import axios from 'axios'

Vue.use(Vuex)

export default new Vuex.Store({
    state: {        
        department: {},
        departments: [],
        employee: {
            department: {}
        },
        errorMessage: ''
    },
    mutations: {
        SET_DEPARTMENTS(state, payload) {
            state.departments = payload
        },
        SET_DEPARTMENT(state, payload) {
            state.department = payload
        },
        SET_EMPLOYEE(state, payload) {
            state.employee = payload
        },
        SET_ERRORMESSAGE(state, payload) {
            state.errorMessage = payload
        }
    },
    actions: {
        async getDepartments({ commit }) {                        
            await axios.get("/api/departments")
            .then((response) => commit('SET_DEPARTMENTS', response.data))
            .catch((error) => commit('SET_ERRORMESSAGE', error.message))               
        },
        async getDepartment({ commit }, departmentId) {                        
            await axios.get("/api/departments/" + departmentId)
            .then((response) => commit('SET_DEPARTMENT', response.data))
            .catch((error) => commit('SET_ERRORMESSAGE', error.message))                
        },
        async getEmployee({ commit }, employeeId) {                        
            await axios.get("/api/employees/" + employeeId)
            .then((response) => commit('SET_EMPLOYEE', response.data))
            .catch((error) => commit('SET_ERRORMESSAGE', error.message))                
        }
    },
    modules: {

    }
})