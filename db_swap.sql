PGDMP     ,    (                w            db_swap    11.5    11.5     a           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                       false            b           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                       false            c           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                       false            d           1262    16393    db_swap    DATABASE     �   CREATE DATABASE db_swap WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Spanish_Peru.1252' LC_CTYPE = 'Spanish_Peru.1252';
    DROP DATABASE db_swap;
             postgres    false            T          0    16615 	   countries 
   TABLE DATA               -   COPY public.countries (id, name) FROM stdin;
    public       postgres    false    202   /       V          0    16623 	   languages 
   TABLE DATA               -   COPY public.languages (id, name) FROM stdin;
    public       postgres    false    204   L       X          0    16631    lessons 
   TABLE DATA               c   COPY public.lessons (id, day, hour, latitude, lenght, student_id, task_id, teacher_id) FROM stdin;
    public       postgres    false    206   i       Z          0    16639    levels 
   TABLE DATA               *   COPY public.levels (id, name) FROM stdin;
    public       postgres    false    208   �       O          0    16396    roles 
   TABLE DATA               )   COPY public.roles (id, name) FROM stdin;
    public       postgres    false    197   �       \          0    16647    sexs 
   TABLE DATA               (   COPY public.sexs (id, name) FROM stdin;
    public       postgres    false    210   �       ^          0    16655    tasks 
   TABLE DATA               )   COPY public.tasks (id, name) FROM stdin;
    public       postgres    false    212   �       P          0    16579 
   user_roles 
   TABLE DATA               6   COPY public.user_roles (user_id, role_id) FROM stdin;
    public       postgres    false    198          R          0    16586    users 
   TABLE DATA               �   COPY public.users (id, active, birthday, description, email, lastname, mobilephone, name, password, teach, username) FROM stdin;
    public       postgres    false    200   /       m           0    0    countries_id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public.countries_id_seq', 1, false);
            public       postgres    false    201            n           0    0    languages_id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public.languages_id_seq', 1, false);
            public       postgres    false    203            o           0    0    lessons_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public.lessons_id_seq', 1, false);
            public       postgres    false    205            p           0    0    levels_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.levels_id_seq', 1, false);
            public       postgres    false    207            q           0    0    roles_id_seq    SEQUENCE SET     :   SELECT pg_catalog.setval('public.roles_id_seq', 2, true);
            public       postgres    false    196            r           0    0    sexs_id_seq    SEQUENCE SET     :   SELECT pg_catalog.setval('public.sexs_id_seq', 1, false);
            public       postgres    false    209            s           0    0    tasks_id_seq    SEQUENCE SET     ;   SELECT pg_catalog.setval('public.tasks_id_seq', 1, false);
            public       postgres    false    211            t           0    0    users_id_seq    SEQUENCE SET     :   SELECT pg_catalog.setval('public.users_id_seq', 1, true);
            public       postgres    false    199            T      x������ � �      V      x������ � �      X      x������ � �      Z      x������ � �      O   !   x�3���q�v�2��]|=��b���� t��      \      x������ � �      ^      x������ � �      P      x�3�4����� d      R   �   x�%��
�@ ��>���~�۩��L�`E�Ֆ�p�5ͨ�O
�8�0 29�9Z��N�C���=�a�-�k)� �ʵ�⦸lܺU�J%�� 1
C�?l��Hm�eǕ)ⓟ�ϛ2Nf{7�ny�^ѓne>��AW�48$rz�WRrq	!_�*0%     