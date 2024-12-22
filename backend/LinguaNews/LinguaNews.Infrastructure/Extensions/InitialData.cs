using LinguaNews.Domain.Models;

namespace LinguaNews.Infrastructure.Extensions;

internal class InitialData
{
    public static IEnumerable<Category> Categories =>
        new List<Category>
        {
            Category.Create(name: "Technology",
                description: "Latest updates and trends in technology, including gadgets, software, and innovation.",
                image: "https://cdn.webrazzi.com/uploads/2023/06/macbook-472.png"),
            Category.Create(
                name: "Health",
                description: "News and insights related to health, wellness, fitness, and medical advancements.",
                image: "https://www.planstreetinc.com/wp-content/uploads/2021/07/what-is-mental-health-1130x675.png"),
            Category.Create(
                name: "Sports",
                description: "Coverage of various sports events, athlete profiles, and sports news.",
                image: "https://wallpapers.com/images/hd/1920x1080-hd-sports-61oi85jh19u3ptld.jpg"
            ),
            Category.Create(
                name: "Entertainment",
                description: "Updates on movies, music, television, and celebrity news.",
                image: "https://images.squarespace-cdn.com/content/v1/59e24d3790bade29a3af48e2/1512916279389-6DNTC7SUHEQPYVSQ8V6S/Entertainment+banner+pic.jpg?format=1500w"
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
                image: "https://heliontechnologies.com/wp-content/uploads/2024/04/AI.jpeg",
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
                image: "https://cdn.mos.cms.futurecdn.net/VFLt5vHV7aCoLrLGjP9Qwm-1200-80.jpg",
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
                image: "https://ichef.bbci.co.uk/ace/standard/1024/cpsprodpb/14202/production/_108243428_gettyimages-871148930.jpg",
                categoryId: 1,
                beginner:
                "Artificial Intelligence is increasingly being adopted by businesses to streamline operations and enhance customer experiences. In this article, we will look at how companies are leveraging AI technologies to optimize their processes and make data-driven decisions. From chatbots in customer service to predictive analytics in marketing, the use of AI is becoming commonplace.",
                intermediate:
                "We will analyze several case studies showcasing successful AI implementations in various sectors, such as healthcare, finance, and retail. You will discover how AI can improve operational efficiency, enhance decision-making, and foster innovation. The discussion will also touch upon the challenges organizations face when integrating AI into their existing systems and workflows.",
                advanced:
                "Finally, we will delve into the ethical implications of AI in business, examining issues such as data privacy, algorithmic bias, and the impact of automation on the workforce. This section will encourage readers to think critically about the responsibility of businesses in utilizing AI technologies and the importance of establishing ethical frameworks to guide AI development and deployment in the corporate world."
            ),
            News.Create(
                id: null,
                title: "The Future of Quantum Computing",
                slug: "future-quantum-computing",
                image: "https://itfix.org.uk/wp-content/uploads/2024/02/Quantum_Computing_and_the_Future_of_Operating_Systems.webp",
                categoryId: 1,
                beginner:
                "Quantum computing is an emerging field that promises to revolutionize computing as we know it. At its core, quantum computing leverages the principles of quantum mechanics to perform computations that are impossible for traditional computers. This article will introduce you to the basics of quantum computing, its potential applications, and why it is a crucial area of research.",
                intermediate:
                "In this section, we will delve deeper into quantum bits (qubits), quantum entanglement, and quantum gates. You will learn how quantum computers differ from classical computers and how they can be used to solve problems like encryption and optimization. We'll also discuss quantum algorithms such as Shor’s algorithm and Grover’s algorithm.",
                advanced:
                "For those with a solid understanding of quantum mechanics, we will explore more complex topics such as quantum error correction, quantum supremacy, and quantum machine learning. This section will provide a detailed analysis of the current challenges in building scalable quantum computers and their potential impact on industries like cryptography and artificial intelligence."
            ),
            News.Create(
                id: null,
                title: "The Rise of Telemedicine",
                slug: "rise-telemedicine",
                image: "https://post.healthline.com/wp-content/uploads/2020/10/telemedicine-psychotherapy-session-from-bed-1296x728-header.jpg",
                categoryId: 2,
                beginner:
                "Telemedicine has emerged as a critical part of healthcare, allowing patients to consult with doctors remotely. In this article, we will explain the basics of telemedicine, including the technology behind virtual consultations and its growing role in healthcare, especially during the pandemic.",
                intermediate:
                "This section will explore the different types of telemedicine services, such as live video consultations, remote patient monitoring, and store-and-forward methods. We'll also discuss the challenges telemedicine faces, such as maintaining patient privacy, reimbursement issues, and regulations.",
                advanced:
                "For healthcare professionals and technologists, this section will cover the integration of AI and machine learning in telemedicine, the future of wearable health devices, and the ethical considerations surrounding telehealth, including patient consent, data security, and equitable access."
            ),
            News.Create(
                id: null,
                title: "The Evolution of eSports",
                slug: "evolution-esports",
                image: "https://worldfootballsummit.com/wp-content/uploads/2022/08/esports.jpeg",
                categoryId: 3,
                beginner:
                "eSports, or competitive video gaming, has become a multi-billion dollar industry. This article will provide an introduction to eSports, its history, and how it has grown from small competitions to international tournaments with millions of viewers and participants.",
                intermediate:
                "As we explore eSports further, we will look at the structure of eSports teams, tournaments, and organizations. This section will also discuss the role of streaming platforms like Twitch and YouTube, and how they have transformed the way we view and engage with competitive gaming.",
                advanced:
                "For those interested in the business and technology behind eSports, we will examine sponsorships, media rights, and the technological innovations shaping the industry. We’ll also explore the challenges and opportunities in maintaining a professional eSports ecosystem, including player well-being, sustainability, and inclusivity."
            ),
            News.Create(
                id: null,
                title: "Artificial Intelligence in Healthcare",
                slug: "ai-healthcare",
                image: "https://successive.cloud/wp-content/uploads/2023/03/AI-in-Healthcare-768x403.jpg",
                categoryId: 2,
                beginner:
                "Artificial Intelligence (AI) is transforming healthcare by improving diagnostics, personalizing treatment plans, and automating administrative tasks. This beginner’s guide will introduce you to AI's applications in healthcare and how it is revolutionizing patient care and medical research.",
                intermediate:
                "In this section, we will explore the use of AI in medical imaging, predictive analytics, and drug discovery. You’ll learn about algorithms that help doctors make better decisions and the challenges of integrating AI into healthcare systems.",
                advanced:
                "For healthcare professionals and researchers, we will discuss advanced AI applications such as deep learning models for personalized medicine, the use of natural language processing in medical records, and the ethical challenges of AI in healthcare, including patient privacy and algorithmic bias."
            ),
            News.Create(
                id: null,
                title: "Sustainable Energy: The Future of Power",
                slug: "sustainable-energy-future",
                image: "https://media.licdn.com/dms/image/v2/D4D12AQFe2OihdSSmag/article-cover_image-shrink_600_2000/article-cover_image-shrink_600_2000/0/1685715736134?e=2147483647&v=beta&t=zFRShPQGJDPTRn1j_T37vfUQisF0UcsNBFy092xSGwI",
                categoryId: 1,
                beginner:
                "Sustainable energy refers to energy that is renewable and has a low environmental impact. In this article, we’ll explain the basics of sustainable energy sources like solar, wind, and hydro power, and why they are crucial for the future of our planet.",
                intermediate:
                "We will explore the technology behind solar panels, wind turbines, and energy storage solutions. This section will also cover the role of government policies, incentives, and private sector investments in driving the adoption of sustainable energy solutions.",
                advanced:
                "For energy experts and enthusiasts, this section will delve into the latest innovations in sustainable energy, such as smart grids, offshore wind farms, and the integration of AI in energy management systems. We will also discuss the challenges of transitioning to renewable energy on a global scale."
            ),
            News.Create(
                id: null,
                title: "The Impact of Social Media on Mental Health",
                slug: "impact-social-media-mental-health",
                image: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRqPEelbILv96jKNT_EwAcRFlwF2RtPniXLQg&s",
                categoryId: 2,
                beginner:
                "Social media has become an integral part of daily life, but its effects on mental health are still being studied. In this article, we will look at the basics of how social media impacts mental well-being and what we can do to mitigate negative effects.",
                intermediate:
                "This section will explore the psychological effects of social media, such as anxiety, depression, and loneliness. We will also discuss the concept of 'social media addiction' and how constant comparison to others can affect self-esteem.",
                advanced:
                "For mental health professionals, this section will cover the latest research on the relationship between social media use and mental health disorders. We will discuss strategies for managing social media use and explore potential solutions, such as digital detoxes and mindfulness techniques."
            ),
            News.Create(
                id: null,
                title: "The Power of AI in the Entertainment Industry",
                slug: "ai-entertainment-industry",
                image: "https://miro.medium.com/max/1200/1*9oBjaymF91UCgKMZUO_vdQ.jpeg",
                categoryId: 4,
                beginner:
                "Artificial Intelligence is making waves in the entertainment industry, from generating content to enhancing viewer experiences. This article will introduce you to AI's role in movies, music, gaming, and more.",
                intermediate:
                "In this section, we will explore how AI is used in scriptwriting, video editing, and game design. You’ll also learn how recommendation systems work on platforms like Netflix and Spotify, and how AI is revolutionizing content personalization.",
                advanced:
                "For those with an interest in the future of entertainment, we’ll discuss AI-driven creativity, such as AI-generated art and music, and the ethical implications of AI in entertainment, including concerns about job displacement and copyright issues."
            ),
            News.Create(
                id: null,
                title: "The Importance of Cybersecurity in the Digital Age",
                slug: "importance-cybersecurity-digital-age",
                image: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT8bI7mvsj2NVg0TAyIdi1KtS3jbR0fm3tsYg&s",
                categoryId: 1,
                beginner:
                "As the world becomes increasingly digital, cybersecurity has never been more important. This article will introduce you to the basics of cybersecurity, why it is essential, and the key concepts to know to protect your personal data and privacy online.",
                intermediate:
                "In this section, we will delve into common cyber threats like phishing, malware, and ransomware. You will learn about security protocols such as encryption and two-factor authentication, as well as strategies for keeping your devices and accounts safe.",
                advanced:
                "For cybersecurity professionals, we will explore topics like penetration testing, blockchain security, and emerging threats in the world of cybercrime. This section will also address the legal and ethical challenges in cybersecurity, including data breaches and compliance with regulations like GDPR."
            ),
            News.Create(
                id: null,
                title: "The Evolution of Streaming Services",
                slug: "evolution-streaming-services",
                image: "https://miro.medium.com/v2/resize:fit:948/1*ORhusgs-F-hijlHIswaEvQ.jpeg",
                categoryId: 4,
                beginner:
                "Streaming services like Netflix, Spotify, and Disney+ have transformed the way we consume media. This article will provide an introduction to streaming services, how they work, and why they have become so popular in recent years.",
                intermediate:
                "This section will cover the evolution of streaming platforms, their business models, and how they impact traditional media like TV and radio. We will also discuss the role of content creation, licensing, and regional availability.",
                advanced:
                "For those interested in the future of entertainment, we will explore the challenges faced by streaming services, such as competition, piracy, and the shift toward live streaming. This section will also discuss the technology behind streaming, including data compression and content delivery networks."
            ),
            News.Create(
                id: null,
                title: "Exploring the Future of Autonomous Vehicles",
                slug: "future-autonomous-vehicles",
                image: "https://gadgets-post.s3.amazonaws.com/wp-content/uploads/2023/10/11173924/Exploring-the-Promise-of-Autonomous-Vehicles.jpg",
                categoryId: 1,
                beginner:
                "Autonomous vehicles, or self-driving cars, are one of the most exciting developments in the automotive industry. This article will introduce you to the concept of autonomous vehicles, how they work, and the potential benefits they offer to society.",
                intermediate:
                "In this section, we will explore the technology behind autonomous vehicles, including sensors, machine learning algorithms, and artificial intelligence. You will also learn about the different levels of automation and the challenges faced by the industry in terms of safety, regulation, and infrastructure.",
                advanced:
                "For those interested in the future of transportation, this section will cover the integration of autonomous vehicles into smart cities, the role of AI in transportation logistics, and the ethical implications of self-driving cars, including issues of liability and decision-making."
            ),
            News.Create(
                id: null,
                title: "The Role of Biotechnology in Modern Medicine",
                slug: "role-biotechnology-medicine",
                image: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSpohfZu-OD5l_5tjzge-disxr10fsNCcBw6Q&s",
                categoryId: 2,
                beginner:
                "Biotechnology has revolutionized modern medicine, enabling breakthroughs in genetic research, drug development, and personalized treatment. This article will introduce you to the basics of biotechnology and its applications in medicine.",
                intermediate:
                "In this section, we will explore the use of CRISPR technology, gene therapy, and biopharmaceuticals in treating diseases. We’ll also discuss the ethical issues surrounding genetic modification and the challenges of making biotechnological innovations accessible to the public.",
                advanced:
                "For professionals in the field, this section will cover cutting-edge research in synthetic biology, stem cell therapy, and the use of biotechnology in regenerative medicine. We will also explore the future of biotechnological advancements and their potential impact on global healthcare systems."
            )
        };
}