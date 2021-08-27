<template>
  <div>
    <div class="small" >
    <h3>Кол-во посещаемости</h3>
    <line-chart :chart-data="datacollection" :chart-options="options"></line-chart>
    </div>
    <div>
   <ReportTablesComponent></ReportTablesComponent>
    </div>
       <button @click="fillData()">Randomize</button>
  </div>

  
</template>

<script>
import LineChart from '@/components/LineChart'
import ReportTablesComponent from '@/components/AdminComponents/ReportTablesComponent.vue'
import axios from 'axios'
 export default {
    components: {
      LineChart,ReportTablesComponent
    },
    data () {
      return {
        datacollection: null,
        options:null,
        Count:[]
      }
    },
    mounted () {
      this.fillData()
    },
    methods: {
      fillData () {

          axios.get('https://localhost:44303/api/Record/visitorcount').then(Response=>{   this.Count = Response.data;console.log(this.Count)})
        this.datacollection = {
          labels: ["Январь","Февраль", "Март", "Апрель","Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"],
          datasets: [
            {
              label: 'Data One',
              backgroundColor: '#f87979',
              data: this.Count
            },   { responsive: false, maintainAspectRatio: false }
          ]
        }
        
              this.options={
          scales: {
            yAxes: [{
              ticks: {
                beginAtZero: true
              },
              gridLines: {
                display: true
              }
            }],
            xAxes: [ {
              gridLines: {
                display: false
              }
            }]
          },
          legend: {
            display: true
          },
          responsive: true,
          maintainAspectRatio: false
        }

      },
     
    }
  }
  
</script>

<style>
  .small {
    max-width: 600px;
    margin:  10px auto;
  }
</style>