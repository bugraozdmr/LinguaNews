using LinguaNews.Domain.Models;

namespace LinguaNews.Infrastructure.Extensions;

internal class InitialData
{
    public static IEnumerable<Category> Categories =>
        new List<Category>
        {
            Category.Create(name: "Technology",
                description: "Latest updates and trends in technology, including gadgets, software, and innovation.",
                image: "path/to/technology-image.jpg"),
            Category.Create(
                name: "Health",
                description: "News and insights related to health, wellness, fitness, and medical advancements.",
                image: "path/to/health-image.jpg"),
            Category.Create(
                name: "Sports",
                description: "Coverage of various sports events, athlete profiles, and sports news.",
                image: "path/to/sports-image.jpg"
            ),
            Category.Create(
                name: "Entertainment",
                description: "Updates on movies, music, television, and celebrity news.",
                image: "path/to/entertainment-image.jpg"
            )
        };

    // cannot be same name otherwise Domain.Tables.News
    public static IEnumerable<News> Newss =>
        new List<News>
        {
            News.Create(
                id: null,
                title: "Understanding the Basics of AI",
                slug: "understanding-basics-ai",
                image: "path/to/beginner-ai-image.jpg",
                categoryId: 1,
                beginner:
                "Artificial Intelligence (AI) is transforming the way we live and work. In this article, we will explore the foundational concepts of AI, including machine learning, natural language processing, and robotics. You will learn about the history of AI and its evolution over the years, along with real-world examples of how AI is currently being applied across various industries. This beginner's guide aims to demystify AI and make it accessible to everyone, regardless of their technical background.",
                intermediate:
                "As we delve deeper into the world of AI, we will discuss the various machine learning techniques that drive AI applications. You will gain insights into supervised and unsupervised learning, decision trees, and neural networks. This section aims to bridge the gap between basic concepts and practical applications, providing a solid understanding of how these algorithms work and their significance in today's technological landscape.",
                advanced:
                "For those looking to deepen their knowledge, we will explore advanced topics such as deep learning, reinforcement learning, and the ethical implications of AI technologies. We will analyze how deep learning models are trained using large datasets and the complexities involved in ensuring ethical AI practices. This section will challenge your understanding and encourage critical thinking about the future of AI and its role in society."
            ),
            News.Create(
                id: null,
                title: "Exploring Machine Learning Techniques",
                slug: "exploring-machine-learning-techniques",
                image: "path/to/intermediate-ml-image.jpg",
                categoryId: 1,
                beginner:
                "Machine learning is a subset of AI that focuses on the development of algorithms that allow computers to learn from and make predictions based on data. In this introductory article, we will outline the key principles of machine learning, providing you with a solid understanding of the basics. You will learn about the data-driven approach of machine learning and how it contrasts with traditional programming methods.",
                intermediate:
                "Building on the basics, we will dive into the various machine learning models, including linear regression, support vector machines, and clustering algorithms. This section will highlight the strengths and weaknesses of each model, guiding you on how to select the appropriate model based on your specific data and problem context. Practical examples will be provided to illustrate how these models are implemented in real-world scenarios.",
                advanced:
                "For more experienced readers, we will investigate the intricacies of neural networks and deep learning architectures. You'll learn about convolutional neural networks (CNNs) for image recognition tasks and recurrent neural networks (RNNs) for time series analysis. We will also discuss the challenges of overfitting, underfitting, and the importance of hyperparameter tuning in developing robust machine learning models."
            ),
            News.Create(
                id: null,
                title: "Advanced AI Applications in Business",
                slug: "advanced-ai-applications-business",
                image: "path/to/advanced-ai-image.jpg",
                categoryId: 1,
                beginner:
                "Artificial Intelligence is increasingly being adopted by businesses to streamline operations and enhance customer experiences. In this article, we will look at how companies are leveraging AI technologies to optimize their processes and make data-driven decisions. From chatbots in customer service to predictive analytics in marketing, the use of AI is becoming commonplace.",
                intermediate:
                "We will analyze several case studies showcasing successful AI implementations in various sectors, such as healthcare, finance, and retail. You will discover how AI can improve operational efficiency, enhance decision-making, and foster innovation. The discussion will also touch upon the challenges organizations face when integrating AI into their existing systems and workflows.",
                advanced:
                "Finally, we will delve into the ethical implications of AI in business, examining issues such as data privacy, algorithmic bias, and the impact of automation on the workforce. This section will encourage readers to think critically about the responsibility of businesses in utilizing AI technologies and the importance of establishing ethical frameworks to guide AI development and deployment in the corporate world."
            )
        };
}