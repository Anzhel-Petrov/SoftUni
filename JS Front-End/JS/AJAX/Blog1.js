// function attachEvents() {
//     let postsUrl = 'http://localhost:3030/jsonstore/blog/posts';
//     let commentsUrl = 'http://localhost:3030/jsonstore/blog/comments';
 
//     let loadBtn = document.getElementById('btnLoadPosts');
//     let viewBtn = document.getElementById('btnViewPost');
 
//     let selectSection = document.getElementById('posts');
//     let postTitle = document.getElementById('post-title');
//     let postBody = document.getElementById('post-body');
//     let list = document.getElementById('post-comments');
 
//     loadBtn.addEventListener('click', loadPosts);
//     viewBtn.addEventListener('click', loadComments);
 
//     async function loadPosts () {
//         try {
//             let posts = await fetch(postsUrl);
//             let postData = await posts.json();
 
//             let postEntries = Object.entries(postData);
 
//             for (let [key, post] of postEntries) {
//                 let newOption = document.createElement('option');
//                 newOption.value = key;
//                 newOption.textContent = post.title;
 
//                 selectSection.appendChild(newOption);
//             }
 
//         } catch (error) {
//             console.error(error);
//         }
//     }
 
//     async function loadComments () {
//         let currentKey = selectSection.value;
//         let currentPost;
 
//         try {
//             let posts = await fetch(postsUrl);
//             let postData = await posts.json();
 
//             let currentPost = postData[currentKey];
 
//             postTitle.textContent = currentPost.title;
//             postBody.textContent = currentPost.body;
 
//         } catch (error) {
//             console.error(error);
//         }
 
//         try {
//             let comments = await fetch(commentsUrl);
//             let commentsData = await comments.json();
//             list.innerHTML = '';
            
//             let filteredComments = Object.values(commentsData).filter(c => c.postId === currentKey);
 
//             filteredComments.forEach(comment => {
//                 const li = document.createElement('li');
//                 li.textContent = comment.text;
//                 list.appendChild(li);
//             });
 
//         } catch (error) {
//             console.log(error);
//         }
//     }
 
// }
 
// attachEvents();

// function attachEvents() {
//     let postUrl = 'http://localhost:3030/jsonstore/blog/posts';
//     let commentsUrl = 'http://localhost:3030/jsonstore/blog/comments';
 
//     document.getElementById('btnLoadPosts').addEventListener('click', () => { onPostsRequest(postUrl) });
//     document.getElementById('btnViewPost').addEventListener('click', () => { onViewPost(commentsUrl) });
// }
 
// async function onPostsRequest(url) {
//     let data;
 
//     try {
//         let response = await fetch(url);
//         data = await response.json();
//     } catch {
//         return;
//     }
 
//     let selectPost = document.getElementById('posts');
 
//     for (let [key, value] of Object.entries(data)) {
//         let option = document.createElement('option');
 
//         option.textContent = value.title;
//         option.value = key;
 
//         selectPost.appendChild(option);
//     }
// }
 
// async function onViewPost(url) {
//     let post = document.getElementById('posts');
//     let postComments;
//     let postData;
 
//     try {
//         const [postResponse, commentsResponse] = await Promise.all([
//             fetch('http://localhost:3030/jsonstore/blog/posts'),
//             fetch(url)
//         ]);
 
//         postData = await postResponse.json();
 
//         let commentsData = await commentsResponse.json();
//         postComments = Object.values(commentsData).filter(comment => comment.postId === post.value);
//     } catch {
//         return;
//     }
 
//     // Fetch-вах поста с URL-а + post.value и после долните две ги сетвах
//     // с postData.title и postData.body. При мен се показваше правилно,
//     // 3ти и 4ти тест не минаваха.
 
//     document.getElementById('post-title').textContent = post.selectedOptions[0].textContent;
//     document.getElementById('post-body').textContent = postData[post.value].body;
    
//     let comments = document.getElementById('post-comments');
//     comments.replaceChildren();
 
//     for (let comment of postComments) {
//         let li = document.createElement('li');
//         li.textContent = comment.text;
//         li.id = comment.id;
 
//         comments.appendChild(li);
//     }
// }   
 
// attachEvents();