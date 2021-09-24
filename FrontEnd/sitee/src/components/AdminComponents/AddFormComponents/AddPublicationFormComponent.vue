<template>
 <div >

    <b-form class=" bg-white" >
      <h1 v-if="$route.meta.EditFormPublication">Редактирование Публикации "{{games.titleofgame}}"</h1>
     <h1 v-if="!$route.meta.EditFormPublication">Добавление новой публикации</h1>
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
        label="Цена:"
        label-for="input-4"
      
      >
        </b-form-group>
      
        <b-form-input
      id="input-4"
      type="number"
      v-model="price"
      placeholder="Enter something..."
      rows="3"
      max-rows="6"
    ></b-form-input>


     <b-form-group
        id="input-group-1"
        label="Серия игр"
        label-for="input-1"
      
      >
      
        <b-form-input
          id="input-1"
         v-model="seriess"
          type="text"
          placeholder="Enter Title"
          required
        ></b-form-input>
      </b-form-group>
    

    

    
      
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
 
    <b-form-group label="Платформы:" v-b-toggle.my-collapse3  >

   
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
          <b-form-file type="file" accept="image/*" multiple="multiple" @change="onFileChange"  class="form-control-file" id="my-file"/>
    
          <div class="border p-2 mt-3">
            <p>Preview Here:</p>
            <template v-if="preview_list.length">
              <div v-for="item, index in preview_list" :key="index" class="container">
                <img :src="item" class="img-fluid" />
                 <button class="btn" @click="RemoveImage(index)">&#x2715</button>
                <p class="mb-0">file name: {{image_list[index].name }}</p>
                <p>size: {{  image_list[index].size/1024 }}KB</p>
                
              </div>
            </template>
          </div>
        </div>
     
    </div>
    </b-form-group> 
        </b-form-group>
        
        


   

  
    
    </b-form>
       <b-button type="submit" variant="primary" @click="upload()">Submit</b-button>
        <notifications group="foo" />
  </div>
</template>

<style >


.container .btn {
    position: absolute;
    top: 0%;
    left:100%;
    transform: translate(-50%, -50%);
    -ms-transform: translate(-50%, -50%);
    background-color: #555;
    color: white;
    font-size: 16px;
    padding: 12px 24px;
    border: none;
    cursor: pointer;
    border-radius: 5px;
    text-align: center;
}
</style>

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
              seriess:"",
              price:0,
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
              publications:[],
               
               
              files:new FormData(),
              preview_list: [],
      image_list: [],
      list:[]
              
            
        
              }
          },
          mounted(){
              if(this.session ==undefined){
                 this.$cookie.set('usersession', 'usersession', { expires: '1h' });

               }

          
            axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
             axios.get("https://localhost:44303/api/Platform").then(Response=> this.platforms=Response.data)
               axios.get("https://localhost:44303/api/Localization").then(Response=> this.localizations=Response.data)
             axios.get("https://localhost:44303/api/Series").then(Response=> this.series=Response.data)
            axios.get("https://localhost:44303/api/Manufacture").then(Response=> this.manufactures=Response.data)
            axios.get("https://localhost:44303/api/Genre").then(Response=> this.genres=Response.data)
            axios.get("https://localhost:44303/api/Country").then(Response=> this.regionrestricts=Response.data)

            if(this.$route.meta.EditFormPublication)     axios.get("https://localhost:44303/api/Catalog/getpublication/"+this.$route.params.id).
            then(Response=> {
                 console.log(Response.data);
            this.selectedseries=Response.data.game.series==null? 1:Response.data.game.series; 
            this.price=Response.data.price; 
            this.games=Response.data.game; 
            this.dateRealese=Response.data.game.dateRealese;
            this.titleofgame=this.games.titleofgame;
            this.seriess=Response.data.game.series==null? 1:this.games.series.titleofseries
            this.description=this.games.description
            this.publications=Response.data
            console.log(this.publications.id)
            
                        
              
           
               
           
         
             for(var i=0; i<Response.data.game.genres.length;i++){
            this.selectedgenres.push(Response.data.game.genres[i].titleofgenre)
            }

             for(var i=0; i<Response.data.game.manufactures.length;i++){
            this.selectedmanufactures.push(Response.data.game.manufactures[i].titleofmanufactures)
          
            }

             for(var i=0; i<Response.data.game.localizations.length;i++){
            this.selectedlocalizations.push(Response.data.game.localizations[i].titleoflocalization)
            }

             for(var i=0; i<Response.data.game.platforms.length;i++){
            this.selectedplatforms.push(Response.data.game.platforms[i].titleofplatform)
            }

             for(var i=0; i<Response.data.game.regionRestricts.length;i++){
            this.selectedregionrestricts.push(Response.data.game.regionRestricts[i].titleofcountry)
            }

              
 
             var reader = new FileReader();
           
            for(var i=0; i<this.publications.images.length; i++){
              const filename= this.publications.images[i].filename;
               console.log(i)
                         this.preview_list.push(this.publications.images[i].url)
               axios.get(this.publications.images[i].url).then(response=>    {
                 var file=new File([response.data], filename, {type:"image/jpg"}); file.$path=""
                 this.image_list.push(file); })
               
         
                   
              

            }

             });


          
          
          },
          
          methods:{
                  fileChange(fileList) {
        this.files.append("file", fileList[0], fileList[0].name);
    },


    
    upload:function() {

        
        axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*'
  console.log(this.image_list)
      let formData = new FormData()
  for (var i = 0; i < this.image_list.length; i++) {
    let file = this.image_list[i]

   formData.append('images', file, file.name)
  }
  console.log(formData)
      
     console.log(this.publications.id)
      if(this.$route.meta.EditFormPublication)
      
      axios({method:'POST', url:`https://localhost:44303/api/Catalog/editpublication/`+this.$route.params.id, headers:{
                    "Accept": "application/json",
                 "Authorization": "Bearer " + localStorage.getItem("admin")},data:formData,params:{images:formData,titleofgame:this.titleofgame,
         description:this.description, dateRealese:this.dateRealese,genres:this.selectedgenres, manufactures:this.selectedmanufactures, platforms:this.selectedplatforms, 
         localizations:this.selectedlocalizations, regionrestricts:this.selectedregionrestricts, series:this.seriess, price:this.price }  }).then(response => {
           this.$notify({
  group: 'foo',
  type:'success',
  duration:10000,
  text: "Успешно!"
});
             
            }).catch(d=>{
              if(d.response)
         
              this.$notify({
  group: 'foo',
  type:'error',
  title: d.response.status,
   duration:10000,
  text: d.message
  
});
  if(d.request){
         console.log(d.request.status)
     this.$notify({
  group: 'foo',
  type:'error',
  title: 'Ошибка',
   duration:10000,
  text:d.message
});
  }
});

else 
        axios({method:'POST', url:`https://localhost:44303/api/Catalog/addPublication`, headers:{
                    "Accept": "application/json",
                 "Authorization": "Bearer " + localStorage.getItem("admin")},data:formData,params:{images:formData,titleofgame:this.titleofgame,
         description:this.description, dateRealese:this.sedateRealese,genres:this.selectedgenres, manufactures:this.selectedmanufactures, platforms:this.selectedplatforms, 
         localizations:this.selectedlocalizations, regionrestricts:this.selectedregionrestricts, series:this.seriess, price:this.price }  }).then(response => {
             this.$notify({
  group: 'foo',
  type:'success',
 
  text: "Успешно!"
});
             
            }).catch(d=>{
              if(d.response)
         
              this.$notify({
  group: 'foo',
  type:'error',
  title: d.response.status,
  text: d.message
});
  if(d.request){
         console.log(d.request.status)
     this.$notify({
  group: 'foo',
  type:'error',
  title: 'Ошибка',
  text:d.message
});
  }
});
    },

    onFileChange(e) {
    
      var files = e.target.files || e.dataTransfer.files;
      if (!files.length) return;
      this.createImage(files);
    },
    createImage(files) {
      
      var vm = this;
      for (var index = 0; index < files.length; index++) {
        var reader = new FileReader();
        reader.onload = function(event) {
          const imageUrl = event.target.result;
           vm.preview_list.push(imageUrl);
           console.log(vm.image_list)
        }
         this.image_list.push(files[index]);
         console.log(this.image_list)
        reader.readAsDataURL(files[index]);
      }
    },
  RemoveImage:function(index){

   this.image_list.splice(index,1);
   this.preview_list.splice(index,1)

  }
          }
  }
  
  
</script>       