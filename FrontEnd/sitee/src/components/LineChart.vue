<script>
  import { Line , mixins} from 'vue-chartjs'
  const { reactiveProp } = mixins
import axios from 'axios'
  export default {
    name:"LineChart",
    extends: Line,
    mixins:[reactiveProp],
    props:['options'],
    data () {
      return {
        Count:[],
        chartData: {
          labels: ["Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"],
          datasets: [
            {
              label: 'Line Chart',
              data:[],
              fill: false,
              borderColor: '#2554FF',
              backgroundColor: '#2554FF',
              borderWidth: 1
            }
          ]
        },
        options: {
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
      }
    },

      mounted () {
        this.renderChart(this.chartData, this.options)
         axios.get('https://localhost:44303/api/Record/visitorcount',{headers:{
                    "Accept": "application/json",
                    "Authorization": "Bearer " + localStorage.getItem("user")}}).then(Response=>{ this.chartData.datasets[0].data=Response.data; this.chartData.labels[0]=["Май", "Апрель"];   console.log(this.Count)})
              console.log(this.chartData.datasets); 
    
    },
    watch: {
chartData: function () {
     this.data.chartData.update()
}
},
  
  }
</script>