<template>
  <div>
    <div class="small" >
    <h3>Кол-во посещаемости</h3>
    <line-chart :chart-data="datacollection" :chart-options="options"></line-chart>
    </div>
    <div>
   
    </div>
       <button @click="fillData()">Получить Текущие</button>
  </div>

  
</template>

<script>
import LineChart from '@/components/LineChart'

import axios from 'axios'
 export default {
    components: {
      LineChart
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
      setInterval( this.fillData,60000)
    },
    methods: {
      fillData () {

          axios.get('https://localhost:44303/api/Record/visitorcount',{headers:{
                    "Accept": "application/json",
                    "Authorization": "Bearer " + localStorage.getItem("admin")
                    ,
                    'set-cookie':document.cookie}}).then(Response=>{   this.Count = Response.data;console.log(this.Count)})
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