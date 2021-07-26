import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/employee',
    name: 'employee',
    component: () => import('../views/Employee.vue')
  },
  {
    path: '/department',
    name: 'department',
    component: () => import('../views/Department.vue')
  },
  {
    path: '/editEmployee/:id',
    name: 'editEmployee',
    component: () => import('../views/EditEmployee.vue')
  },
  {
    path: '/editDepartment/:id',
    name: 'editDepartment',
    component: () => import('../views/EditDepartment.vue')
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
