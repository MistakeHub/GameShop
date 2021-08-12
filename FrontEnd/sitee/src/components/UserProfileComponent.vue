<template>

<div class="row py-5 px-4">
    <div class="col-md-5 mx-auto">
        <!-- Profile widget -->
        <div class="bg-white shadow rounded overflow-hidden">
            <div class="px-4 pt-0 pb-4 cover">
                <div class="media align-items-end profile-head">
                    <div class="profile mr-3"><img :src="user.avatar==null?'https://localhost:44303/getImage/Avatar/Default.jpg':user.avatar.url" alt="..." style="max-widht:180px; max-height:220px" class="rounded mb-2 img-thumbnail">
                           <h4 class="mt-0 mb-0">{{user.login}}</h4>
                                <form enctype="multipart/form-data">
        <input type="file" name="photo"  v-on:change="fileChange($event.target.files)"/>
        <button type="button" class="btn btn-outline-dark btn-sm btn-block" @click="upload()">Upload</button>
    </form>
                    <div class="media-body mb-5 text-white">
                 
                        <p class="small mb-4"> <i class="fas fa-map-marker-alt mr-2"></i>New York</p>
                    </div>
        
                </div>
            </div>
            <div class="bg-light p-4 d-flex justify-content-end text-center">
                <ul class="list-inline mb-0">
                    <li class="list-inline-item">
                        <h5 class="font-weight-bold mb-0 d-block">{{user.comments.length}}</h5><small class="text-muted"> <i class="fas fa-image mr-1"></i>Comments</small>
                    </li>
                 
                </ul>
            </div>
            <div class="px-4 py-3">
                <h5 class="mb-0">About</h5>
                <div class="p-4 rounded shadow-sm bg-light">
                    <p class="font-italic mb-0">Web Developer</p>
                    <p class="font-italic mb-0">Lives in New York</p>
                    <p class="font-italic mb-0">Photographer</p>
                </div>
            </div>
            <div class="py-4 px-4">
                <div class="d-flex align-items-center justify-content-between mb-3">
                    <h5 class="mb-0">Recent photos</h5><a href="#" class="btn btn-link text-muted">Show all</a>
                </div>
             
            </div>
        </div>
    </div>
</div>
</div>
    
</template>
<style >
.profile-head {
    transform: translateY(5rem)
}

.cover {

    background-size: cover;
    background-repeat: no-repeat
}

body {
    background: #654ea3;
    background: linear-gradient(to right, #e96443, #904e95);
    min-height: 100vh;
    overflow-x: hidden
}
</style>
<script>


import axios from 'axios'
  export default{
  props: {
  },
     
          name: 'UserProfileComponent',
          data(){
              return{
                 user:{},
               files: new FormData()
              }
          },
          mounted(){
            axios.get("https://localhost:44303/getuser/"+this.$route.params.userlogin).then((response)=> {this.user=response.data; console.log(this.user)});

          },
          methods: {
      
            fileChange(fileList) {
        this.files.append("photo", fileList[0], fileList[0].name);
        console.log(fileList[0].name)
    },

             upload: function(){
        const photo = this.files;
        axios.post("https://localhost:44303/uploadavatar/"+this.user.login, photo,
            {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            }).then(response => {
                window.location.reload();
            }).catch(error => {
                console.log(error);
            })},

      
   
          }
    
  }

</script>

