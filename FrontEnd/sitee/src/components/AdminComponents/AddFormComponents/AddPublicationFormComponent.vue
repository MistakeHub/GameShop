<template>
 <div >

    <b-form class=" bg-white" >

     <h1>Регистрация</h1>
      <b-form-group
        id="input-group-1"
        label="Название Игры:"
        label-for="input-1"
      
      >
      
        <b-form-input
          id="input-1"
         v-model="titleofgame"
          type="text"
          placeholder="Enter Title"
          required
        ></b-form-input>
      </b-form-group>

        <b-form-group
        id="input-group-1"
        label="Описание:"
        label-for="input-2"
      
      >
        </b-form-group>
      
        <b-form-textarea
      id="input-2"
      v-model="description"
      placeholder="Enter something..."
      rows="3"
      max-rows="6"
    ></b-form-textarea>
    

      <b-form-group
        id="input-group-1"
        label="Дата Выхода:"
        label-for="input-3"
      
      >
      
      <b-form-datepicker id="input-3" v-model="dateRealese" class="mb-2"></b-form-datepicker>
      </b-form-group>

          <b-form-group
        id="input-group-1"
        label="Дата Выхода:"
        label-for="input-3"
      
      >
      
      

    
      
      <b-form-checkbox-group
      v-for="elem in genres"
        id="checkbox-group-2"
      
    
        name="flavour-2"
      >
        <b-form-checkbox :value=elem class="d-flex justify-content-start"  v-model="selectedgenres" >{{elem}}</b-form-checkbox>
     
      </b-form-checkbox-group>
    
    </b-form-group>
   <b-form-group label="Производители" v-b-toggle.my-collapse2  >

   
      <b-form-checkbox-group
      v-for="elem in manufactures"
        id="checkbox-group-2"
     
   
        name="flavour-2"
      >
        <b-form-checkbox :value=elem class="d-flex justify-content-start"  v-model="selectedmanufactures">{{elem}}</b-form-checkbox>
     
      </b-form-checkbox-group>
   
    </b-form-group>
 
    <b-form-group label="Палтформа:" v-b-toggle.my-collapse3  >

   
      <b-form-checkbox-group
      v-for="elem in platforms"
        id="checkbox-group-2"
    
     
        name="flavour-2"
      >
        <b-form-checkbox :value=elem class="d-flex justify-content-start"  v-model="selectedplatforms">{{elem}}</b-form-checkbox>
     
      </b-form-checkbox-group>
    
    </b-form-group>

 
      <b-form-group label="Языки:" v-b-toggle.my-collapse4  >

    
      <b-form-checkbox-group
      v-for="elem in localizations"
        id="checkbox-group-2"
       
     
        name="flavour-2"
      >
        <b-form-checkbox :value=elem class="d-flex justify-content-start"  v-model="selectedlocalizations"  >{{elem}}</b-form-checkbox>
     
      </b-form-checkbox-group>

   <b-form-group label="Региональные ограничения:" v-b-toggle.my-collapse4  >
<b-form-checkbox-group
      v-for="elem in regionrestricts"
        id="checkbox-group-2"
       
   
        name="flavour-2"
      >
        <b-form-checkbox :value=elem class="d-flex justify-content-start"  v-model="selectedregionrestricts"  >{{elem}}</b-form-checkbox>
     
      </b-form-checkbox-group>
    
      
      <div class="col-md-5">
      <h5>2. multiple file</h5>
     
        <div class="form-group">
          <label for="my-file">Select Image</label>
          <b-form-file type="file" accept="image/*" multiple="multiple" @change="previewMultiImage" v-model="image_list" class="form-control-file" id="my-file"/>
    
          <div class="border p-2 mt-3">
            <p>Preview Here:</p>
            <template v-if="preview_list.length">
              <div v-for="item, index in preview_list" :key="index">
                <img :src="item" class="img-fluid" />
                <p class="mb-0">file name: {{ image_list[index].name }}</p>
                <p>size: {{ image_list[index].size/1024 }}KB</p>
              </div>
            </template>
          </div>
        </div>
     
    </div>
    </b-form-group> 
        </b-form-group>
        
        


   

  
    
    </b-form>
       <b-button type="submit" variant="primary" @click="upload()">Submit</b-button>
  </div>
</template>

<script>

import axios from 'axios'
  export default{
    
  props: {
  },
     
          name: 'AddPublicationFormComponent',
          data(){
              return{
      titleofgame:"",
      description:"",
      dateRealese:"",
              games:[],
              genres:[],
              manufactures:[],
              series:[],
              localizations:[],
              platforms:[],
              regionrestricts:[],
              selectedgames:[],
               selectedgenres:[],
               selectedmanufactures:[],
               selectedseries:[],
               selectedlocalizations:[],
               selectedplatforms:[],
              selectedregionrestricts:[],
               
               
              files:new FormData(),
              preview_list: [],
      image_list: [],
      list:[]
              
            
        
              }
          },
          mounted(){
            axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
             axios.get("https://localhost:44303/api/Platform").then(Response=> this.platforms=Response.data)
               axios.get("https://localhost:44303/api/Localization").then(Response=> this.localizations=Response.data)
             axios.get("https://localhost:44303/api/Series").then(Response=> this.series=Response.data)
            axios.get("https://localhost:44303/api/Manufacture").then(Response=> this.manufactures=Response.data)
            axios.get("https://localhost:44303/api/Genre").then(Response=> this.genres=Response.data)
            axios.get("https://localhost:44303/api/Country").then(Response=> this.regionrestricts=Response.data)
          
          },
          
          methods:{
                  fileChange(fileList) {
        this.files.append("file", fileList[0], fileList[0].name);
    },


    
    upload:function() {

        
        axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*'
  
      let formData = new FormData()
  for (var i = 0; i < this.image_list.length; i++) {
    let file = this.image_list[i]

   formData.append('images', file, file.name)
  }
  console.log(formData)
      


        axios({method:'POST', url:`https://localhost:44303/api/Catalog/addPublication`, data:formData,params:{images:formData,titleofgame:this.titleofgame,
         description:this.description, dateRealese:this.sedateRealese,genres:this.selectedgenres, manufactures:this.selectedmanufactures, platforms:this.selectedplatforms, 
         localizations:this.selectedlocalizations, regionrestricts:this.selectedregionrestricts }  }).then(response => {
                alert(response.data);
            }).catch(error => {
                console.log(error);
            });
    },

    previewMultiImage: function(event) {
      var input = event.target;
      var count = input.files.length;
      var index = 0;

          
      if (input.files) {
        while(count --) {
          var reader = new FileReader();
          reader.onload = (e) => {
            this.preview_list.push(e.target.result);
          }
          this.image_list.push(input.files[index]);
          console.log(this.image_list);
          reader.readAsDataURL(input.files[index]);
          index ++;
        }
          }

          
  },
          }
  }
  
  
</script>       