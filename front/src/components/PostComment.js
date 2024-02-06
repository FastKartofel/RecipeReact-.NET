import React, { useState, useEffect } from 'react';
import axios from 'axios';

function PostComment() {
    const [content, setContent] = useState('');
    const [comments, setComments] = useState([]);

    useEffect(() => {
        fetchComments();
    }, []);

    const fetchComments = async () => {
        const token = localStorage.getItem('token');
        if (!token) {
            alert('No token found, please log in.');
            return;
        }
        try {
            const response = await axios.get('http://localhost:5000/api/comments', {
                headers: { Authorization: `Bearer ${token}` }
            });
            setComments(response.data);
        } catch (error) {
            console.error('Error fetching comments:', error);
            alert('Error fetching comments. Please try again.');
        }
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        const token = localStorage.getItem('token');
        try {
            await axios.post('http://localhost:5000/api/comments', { content }, {
                headers: { Authorization: `Bearer ${token}` }
            });
            setContent('');
            fetchComments(); // Refresh the comments after posting
        } catch (error) {
            console.error('Failed to post comment:', error);
            alert('Failed to post comment. Please try again.');
        }
    };


    return (
        <div>
            <h2>Comments</h2>
            <form onSubmit={handleSubmit}>
                <textarea value={content} onChange={e => setContent(e.target.value)} required />
                <button type="submit">Post Comment</button>
            </form>
            {comments.map(comment => (
                <div key={comment.commentId}>
                    <p>{comment.content}</p>
                    <small>Posted by: {comment.user.username} on {new Date(comment.datePosted).toLocaleString()}</small>
                </div>
            ))}
        </div>
    );
}

export default PostComment;
