import React, { useState } from 'react';
import axios from 'axios';

function PostComment() {
    const [content, setContent] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const token = localStorage.getItem('token');
            await axios.post('http://localhost:5000/api/comments',
                { content },
                { headers: { Authorization: `Bearer ${token}` } }
            );
            setContent('');
            alert('Comment posted successfully!');
        } catch (error) {
            console.error('Failed to post comment:', error);
            // Handle post error (e.g., show a message to the user)
        }
    };

    return (
        <div>
            <h2>Post a Comment</h2>
            <form onSubmit={handleSubmit}>
                <textarea value={content} onChange={e => setContent(e.target.value)} required />
                <button type="submit">Post Comment</button>
            </form>
        </div>
    );
}

export default PostComment;
