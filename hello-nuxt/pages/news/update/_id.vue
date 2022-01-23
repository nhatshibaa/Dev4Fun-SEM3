<template>
    <main id="js-page-content" role="main" class="page-content">
        <ol class="breadcrumb page-breadcrumb">
            <li class="breadcrumb-item"><a href="javascript:void(0);">SmartAdmin</a></li>
            <li class="breadcrumb-item">Form Stuff</li>
            <li class="breadcrumb-item active">Basic Inputs</li>
            <li class="position-absolute pos-top pos-right d-none d-sm-block"><span class="js-get-date"></span></li>
        </ol>

        <div class="row">
            <div class="col-xl-12">
                <div id="panel-3" class="panel">
                    <div class="panel-hdr">
                        <h2>
                            Update Form
                        </h2>
                        <div class="panel-toolbar">
                            <button class="btn btn-panel" data-action="panel-collapse" data-toggle="tooltip"
                                    data-offset="0,10" data-original-title="Collapse"></button>
                            <button class="btn btn-panel" data-action="panel-fullscreen" data-toggle="tooltip"
                                    data-offset="0,10" data-original-title="Fullscreen"></button>
                            <button class="btn btn-panel" data-action="panel-close" data-toggle="tooltip"
                                    data-offset="0,10" data-original-title="Close"></button>
                        </div>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <form @submit.prevent="onSave()">
                                <div class="form-group">
                                    <label class="form-label">Title</label>
                                    <input type="text" v-model="article.title"
                                           class="form-control form-control-sm">
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Url</label>
                                    <input type="text" v-model="article.url"
                                           class="form-control form-control-sm">
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Thumbnail</label>
                                    <input type="text" v-model="article.thumbnail"
                                           class="form-control form-control-sm">
                                </div>
                                <div v-if="article.thumbnail">
                                    <div class="form-group">
                                        <img :src="article.thumbnail" width="100px" :alt="article.thumbnail">
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="form-label" for="inputGroupSelect02">Category</label>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <select class="custom-select" @change="selectOption($event)"
                                                    id="inputGroupSelect02">
                                                <option value="tin-thi-truong" selected>Tin thị trường</option>
                                                <option value="tin-cong-ty">Tin công ty</option>
                                            </select>
                                            <div class="input-group-append">
                                                <label class="input-group-text" for="inputGroupSelect02">Options</label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="example-input-normal" class="form-label">Description</label>
                                    <input type="text" id="example-input-normal" v-model="article.description"
                                           name="example-input-normal"
                                           class="form-control">
                                </div>
                                <div class="form-group">
                                    <label class="form-label" for="ckeditor">Detail</label>
                                    <textarea class="form-control" v-model="article.detail" id="ckeditor"
                                              rows="5"></textarea>
                                </div>
                                <div class="form-group">
                                    <label for="example-input-large" class="form-label">Source (can null)</label>
                                    <input type="text" id="example-input-large" name="example-input-large"
                                           class="form-control form-control-lg" v-model="article.source">
                                </div>
                                <button class="btn btn-primary ml-auto waves-effect waves-themed" type="submit">Submit
                                    form
                                </button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</template>
<script>

export default {
    data() {
        return {
            article: {
                url: '',
                thumbnail: '',
                title: '',
                category: '',
                description: '',
                detail: '',
                source: '',
            },
        }
    },
    async created() {
        const uri = `/news/${this.$route.params.id}`;
        this.article = await this.$axios.$get(uri);
    },
    methods:{
        onSave(){
            const uri = `/article/update/${this.$route.params.id}`;
            this.$axios.post(uri, this.article).then((response) => {
                this.$router.push('/news');
            });
        },
        selectOption(event){
            this.article.category= event.target.value;
        },

    }
}

</script>

