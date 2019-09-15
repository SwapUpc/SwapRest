PGDMP     )                    w            db_swap    11.5    11.5 O    k           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                       false            l           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                       false            m           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                       false            n           1262    16393    db_swap    DATABASE     �   CREATE DATABASE db_swap WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Spanish_Peru.1252' LC_CTYPE = 'Spanish_Peru.1252';
    DROP DATABASE db_swap;
             postgres    false            �            1259    16615 	   countries    TABLE     \   CREATE TABLE public.countries (
    id integer NOT NULL,
    name character varying(100)
);
    DROP TABLE public.countries;
       public         postgres    false            �            1259    16613    countries_id_seq    SEQUENCE     �   CREATE SEQUENCE public.countries_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public.countries_id_seq;
       public       postgres    false    199            o           0    0    countries_id_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE public.countries_id_seq OWNED BY public.countries.id;
            public       postgres    false    198            �            1259    16742 	   languages    TABLE     `   CREATE TABLE public.languages (
    id integer NOT NULL,
    language character varying(255)
);
    DROP TABLE public.languages;
       public         postgres    false            �            1259    16740    languages_id_seq    SEQUENCE     �   CREATE SEQUENCE public.languages_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public.languages_id_seq;
       public       postgres    false    205            p           0    0    languages_id_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE public.languages_id_seq OWNED BY public.languages.id;
            public       postgres    false    204            �            1259    16938    lessons    TABLE     )  CREATE TABLE public.lessons (
    id integer NOT NULL,
    day timestamp without time zone NOT NULL,
    hour timestamp without time zone NOT NULL,
    latitude double precision NOT NULL,
    lenght double precision NOT NULL,
    student_id integer,
    task_id integer,
    teacher_id integer
);
    DROP TABLE public.lessons;
       public         postgres    false            �            1259    16936    lessons_id_seq    SEQUENCE     �   CREATE SEQUENCE public.lessons_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public.lessons_id_seq;
       public       postgres    false    209            q           0    0    lessons_id_seq    SEQUENCE OWNED BY     A   ALTER SEQUENCE public.lessons_id_seq OWNED BY public.lessons.id;
            public       postgres    false    208            �            1259    16750    levels    TABLE     Z   CREATE TABLE public.levels (
    id integer NOT NULL,
    level character varying(255)
);
    DROP TABLE public.levels;
       public         postgres    false            �            1259    16748    levels_id_seq    SEQUENCE     �   CREATE SEQUENCE public.levels_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 $   DROP SEQUENCE public.levels_id_seq;
       public       postgres    false    207            r           0    0    levels_id_seq    SEQUENCE OWNED BY     ?   ALTER SEQUENCE public.levels_id_seq OWNED BY public.levels.id;
            public       postgres    false    206            �            1259    16396    roles    TABLE     W   CREATE TABLE public.roles (
    id integer NOT NULL,
    name character varying(60)
);
    DROP TABLE public.roles;
       public         postgres    false            �            1259    16394    roles_id_seq    SEQUENCE     �   CREATE SEQUENCE public.roles_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 #   DROP SEQUENCE public.roles_id_seq;
       public       postgres    false    197            s           0    0    roles_id_seq    SEQUENCE OWNED BY     =   ALTER SEQUENCE public.roles_id_seq OWNED BY public.roles.id;
            public       postgres    false    196            �            1259    16647    sexs    TABLE     V   CREATE TABLE public.sexs (
    id integer NOT NULL,
    name character varying(50)
);
    DROP TABLE public.sexs;
       public         postgres    false            �            1259    16645    sexs_id_seq    SEQUENCE     �   CREATE SEQUENCE public.sexs_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 "   DROP SEQUENCE public.sexs_id_seq;
       public       postgres    false    201            t           0    0    sexs_id_seq    SEQUENCE OWNED BY     ;   ALTER SEQUENCE public.sexs_id_seq OWNED BY public.sexs.id;
            public       postgres    false    200            �            1259    16655    tasks    TABLE     X   CREATE TABLE public.tasks (
    id integer NOT NULL,
    name character varying(255)
);
    DROP TABLE public.tasks;
       public         postgres    false            �            1259    16653    tasks_id_seq    SEQUENCE     �   CREATE SEQUENCE public.tasks_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 #   DROP SEQUENCE public.tasks_id_seq;
       public       postgres    false    203            u           0    0    tasks_id_seq    SEQUENCE OWNED BY     =   ALTER SEQUENCE public.tasks_id_seq OWNED BY public.tasks.id;
            public       postgres    false    202            �            1259    16944    user_languages    TABLE     �   CREATE TABLE public.user_languages (
    user_id integer NOT NULL,
    level_id integer NOT NULL,
    language_id integer NOT NULL
);
 "   DROP TABLE public.user_languages;
       public         postgres    false            �            1259    16949 
   user_roles    TABLE     _   CREATE TABLE public.user_roles (
    user_id integer NOT NULL,
    role_id integer NOT NULL
);
    DROP TABLE public.user_roles;
       public         postgres    false            �            1259    16956    users    TABLE     �  CREATE TABLE public.users (
    id integer NOT NULL,
    active boolean NOT NULL,
    birthday timestamp without time zone NOT NULL,
    description character varying(255),
    email character varying(255),
    lastname character varying(255),
    mobilephone character varying(50),
    name character varying(255),
    password character varying(150),
    teach boolean NOT NULL,
    username character varying(30)
);
    DROP TABLE public.users;
       public         postgres    false            �            1259    16954    users_id_seq    SEQUENCE     �   CREATE SEQUENCE public.users_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 #   DROP SEQUENCE public.users_id_seq;
       public       postgres    false    213            v           0    0    users_id_seq    SEQUENCE OWNED BY     =   ALTER SEQUENCE public.users_id_seq OWNED BY public.users.id;
            public       postgres    false    212            �
           2604    16618    countries id    DEFAULT     l   ALTER TABLE ONLY public.countries ALTER COLUMN id SET DEFAULT nextval('public.countries_id_seq'::regclass);
 ;   ALTER TABLE public.countries ALTER COLUMN id DROP DEFAULT;
       public       postgres    false    199    198    199            �
           2604    16745    languages id    DEFAULT     l   ALTER TABLE ONLY public.languages ALTER COLUMN id SET DEFAULT nextval('public.languages_id_seq'::regclass);
 ;   ALTER TABLE public.languages ALTER COLUMN id DROP DEFAULT;
       public       postgres    false    204    205    205            �
           2604    16941 
   lessons id    DEFAULT     h   ALTER TABLE ONLY public.lessons ALTER COLUMN id SET DEFAULT nextval('public.lessons_id_seq'::regclass);
 9   ALTER TABLE public.lessons ALTER COLUMN id DROP DEFAULT;
       public       postgres    false    208    209    209            �
           2604    16753 	   levels id    DEFAULT     f   ALTER TABLE ONLY public.levels ALTER COLUMN id SET DEFAULT nextval('public.levels_id_seq'::regclass);
 8   ALTER TABLE public.levels ALTER COLUMN id DROP DEFAULT;
       public       postgres    false    207    206    207            �
           2604    16399    roles id    DEFAULT     d   ALTER TABLE ONLY public.roles ALTER COLUMN id SET DEFAULT nextval('public.roles_id_seq'::regclass);
 7   ALTER TABLE public.roles ALTER COLUMN id DROP DEFAULT;
       public       postgres    false    196    197    197            �
           2604    16650    sexs id    DEFAULT     b   ALTER TABLE ONLY public.sexs ALTER COLUMN id SET DEFAULT nextval('public.sexs_id_seq'::regclass);
 6   ALTER TABLE public.sexs ALTER COLUMN id DROP DEFAULT;
       public       postgres    false    201    200    201            �
           2604    16658    tasks id    DEFAULT     d   ALTER TABLE ONLY public.tasks ALTER COLUMN id SET DEFAULT nextval('public.tasks_id_seq'::regclass);
 7   ALTER TABLE public.tasks ALTER COLUMN id DROP DEFAULT;
       public       postgres    false    202    203    203            �
           2604    16959    users id    DEFAULT     d   ALTER TABLE ONLY public.users ALTER COLUMN id SET DEFAULT nextval('public.users_id_seq'::regclass);
 7   ALTER TABLE public.users ALTER COLUMN id DROP DEFAULT;
       public       postgres    false    212    213    213            Z          0    16615 	   countries 
   TABLE DATA               -   COPY public.countries (id, name) FROM stdin;
    public       postgres    false    199   �U       `          0    16742 	   languages 
   TABLE DATA               1   COPY public.languages (id, language) FROM stdin;
    public       postgres    false    205   �U       d          0    16938    lessons 
   TABLE DATA               c   COPY public.lessons (id, day, hour, latitude, lenght, student_id, task_id, teacher_id) FROM stdin;
    public       postgres    false    209   �U       b          0    16750    levels 
   TABLE DATA               +   COPY public.levels (id, level) FROM stdin;
    public       postgres    false    207   V       X          0    16396    roles 
   TABLE DATA               )   COPY public.roles (id, name) FROM stdin;
    public       postgres    false    197   VV       \          0    16647    sexs 
   TABLE DATA               (   COPY public.sexs (id, name) FROM stdin;
    public       postgres    false    201   �V       ^          0    16655    tasks 
   TABLE DATA               )   COPY public.tasks (id, name) FROM stdin;
    public       postgres    false    203   �V       e          0    16944    user_languages 
   TABLE DATA               H   COPY public.user_languages (user_id, level_id, language_id) FROM stdin;
    public       postgres    false    210   �V       f          0    16949 
   user_roles 
   TABLE DATA               6   COPY public.user_roles (user_id, role_id) FROM stdin;
    public       postgres    false    211   W       h          0    16956    users 
   TABLE DATA               �   COPY public.users (id, active, birthday, description, email, lastname, mobilephone, name, password, teach, username) FROM stdin;
    public       postgres    false    213   ?W       w           0    0    countries_id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public.countries_id_seq', 1, false);
            public       postgres    false    198            x           0    0    languages_id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public.languages_id_seq', 3, true);
            public       postgres    false    204            y           0    0    lessons_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public.lessons_id_seq', 1, false);
            public       postgres    false    208            z           0    0    levels_id_seq    SEQUENCE SET     ;   SELECT pg_catalog.setval('public.levels_id_seq', 5, true);
            public       postgres    false    206            {           0    0    roles_id_seq    SEQUENCE SET     :   SELECT pg_catalog.setval('public.roles_id_seq', 2, true);
            public       postgres    false    196            |           0    0    sexs_id_seq    SEQUENCE SET     :   SELECT pg_catalog.setval('public.sexs_id_seq', 1, false);
            public       postgres    false    200            }           0    0    tasks_id_seq    SEQUENCE SET     :   SELECT pg_catalog.setval('public.tasks_id_seq', 4, true);
            public       postgres    false    202            ~           0    0    users_id_seq    SEQUENCE SET     :   SELECT pg_catalog.setval('public.users_id_seq', 3, true);
            public       postgres    false    212            �
           2606    16620    countries countries_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.countries
    ADD CONSTRAINT countries_pkey PRIMARY KEY (id);
 B   ALTER TABLE ONLY public.countries DROP CONSTRAINT countries_pkey;
       public         postgres    false    199            �
           2606    16747    languages languages_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.languages
    ADD CONSTRAINT languages_pkey PRIMARY KEY (id);
 B   ALTER TABLE ONLY public.languages DROP CONSTRAINT languages_pkey;
       public         postgres    false    205            �
           2606    16943    lessons lessons_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.lessons
    ADD CONSTRAINT lessons_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.lessons DROP CONSTRAINT lessons_pkey;
       public         postgres    false    209            �
           2606    16755    levels levels_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public.levels
    ADD CONSTRAINT levels_pkey PRIMARY KEY (id);
 <   ALTER TABLE ONLY public.levels DROP CONSTRAINT levels_pkey;
       public         postgres    false    207            �
           2606    16401    roles roles_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY public.roles
    ADD CONSTRAINT roles_pkey PRIMARY KEY (id);
 :   ALTER TABLE ONLY public.roles DROP CONSTRAINT roles_pkey;
       public         postgres    false    197            �
           2606    16652    sexs sexs_pkey 
   CONSTRAINT     L   ALTER TABLE ONLY public.sexs
    ADD CONSTRAINT sexs_pkey PRIMARY KEY (id);
 8   ALTER TABLE ONLY public.sexs DROP CONSTRAINT sexs_pkey;
       public         postgres    false    201            �
           2606    16660    tasks tasks_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY public.tasks
    ADD CONSTRAINT tasks_pkey PRIMARY KEY (id);
 :   ALTER TABLE ONLY public.tasks DROP CONSTRAINT tasks_pkey;
       public         postgres    false    203            �
           2606    17012 !   users uk6dotkott2kjsp8vw4d0m25fb7 
   CONSTRAINT     ]   ALTER TABLE ONLY public.users
    ADD CONSTRAINT uk6dotkott2kjsp8vw4d0m25fb7 UNIQUE (email);
 K   ALTER TABLE ONLY public.users DROP CONSTRAINT uk6dotkott2kjsp8vw4d0m25fb7;
       public         postgres    false    213            �
           2606    16966 "   users uk_6dotkott2kjsp8vw4d0m25fb7 
   CONSTRAINT     ^   ALTER TABLE ONLY public.users
    ADD CONSTRAINT uk_6dotkott2kjsp8vw4d0m25fb7 UNIQUE (email);
 L   ALTER TABLE ONLY public.users DROP CONSTRAINT uk_6dotkott2kjsp8vw4d0m25fb7;
       public         postgres    false    213            �
           2606    16420 "   roles uk_nb4h0p6txrmfc0xbrd1kglp9t 
   CONSTRAINT     ]   ALTER TABLE ONLY public.roles
    ADD CONSTRAINT uk_nb4h0p6txrmfc0xbrd1kglp9t UNIQUE (name);
 L   ALTER TABLE ONLY public.roles DROP CONSTRAINT uk_nb4h0p6txrmfc0xbrd1kglp9t;
       public         postgres    false    197            �
           2606    16968 "   users uk_r43af9ap4edm43mmtq01oddj6 
   CONSTRAINT     a   ALTER TABLE ONLY public.users
    ADD CONSTRAINT uk_r43af9ap4edm43mmtq01oddj6 UNIQUE (username);
 L   ALTER TABLE ONLY public.users DROP CONSTRAINT uk_r43af9ap4edm43mmtq01oddj6;
       public         postgres    false    213            �
           2606    17010 !   users ukr43af9ap4edm43mmtq01oddj6 
   CONSTRAINT     `   ALTER TABLE ONLY public.users
    ADD CONSTRAINT ukr43af9ap4edm43mmtq01oddj6 UNIQUE (username);
 K   ALTER TABLE ONLY public.users DROP CONSTRAINT ukr43af9ap4edm43mmtq01oddj6;
       public         postgres    false    213            �
           2606    16948 "   user_languages user_languages_pkey 
   CONSTRAINT     r   ALTER TABLE ONLY public.user_languages
    ADD CONSTRAINT user_languages_pkey PRIMARY KEY (user_id, language_id);
 L   ALTER TABLE ONLY public.user_languages DROP CONSTRAINT user_languages_pkey;
       public         postgres    false    210    210            �
           2606    16953    user_roles user_roles_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public.user_roles
    ADD CONSTRAINT user_roles_pkey PRIMARY KEY (user_id, role_id);
 D   ALTER TABLE ONLY public.user_roles DROP CONSTRAINT user_roles_pkey;
       public         postgres    false    211    211            �
           2606    16964    users users_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);
 :   ALTER TABLE ONLY public.users DROP CONSTRAINT users_pkey;
       public         postgres    false    213            �
           2606    16989 *   user_languages fk3noekmeegvms77intl40sydai    FK CONSTRAINT     �   ALTER TABLE ONLY public.user_languages
    ADD CONSTRAINT fk3noekmeegvms77intl40sydai FOREIGN KEY (language_id) REFERENCES public.languages(id);
 T   ALTER TABLE ONLY public.user_languages DROP CONSTRAINT fk3noekmeegvms77intl40sydai;
       public       postgres    false    210    2755    205            �
           2606    16984 *   user_languages fk6ugq8y662r1sqcv4d1a618edi    FK CONSTRAINT     �   ALTER TABLE ONLY public.user_languages
    ADD CONSTRAINT fk6ugq8y662r1sqcv4d1a618edi FOREIGN KEY (level_id) REFERENCES public.levels(id);
 T   ALTER TABLE ONLY public.user_languages DROP CONSTRAINT fk6ugq8y662r1sqcv4d1a618edi;
       public       postgres    false    210    207    2757            �
           2606    16969 #   lessons fk843n4rnjdhi154ra8472wg8ho    FK CONSTRAINT     �   ALTER TABLE ONLY public.lessons
    ADD CONSTRAINT fk843n4rnjdhi154ra8472wg8ho FOREIGN KEY (student_id) REFERENCES public.users(id);
 M   ALTER TABLE ONLY public.lessons DROP CONSTRAINT fk843n4rnjdhi154ra8472wg8ho;
       public       postgres    false    2773    213    209            �
           2606    16979 #   lessons fkes95yw68i7qsrabf92vsepcth    FK CONSTRAINT     �   ALTER TABLE ONLY public.lessons
    ADD CONSTRAINT fkes95yw68i7qsrabf92vsepcth FOREIGN KEY (teacher_id) REFERENCES public.users(id);
 M   ALTER TABLE ONLY public.lessons DROP CONSTRAINT fkes95yw68i7qsrabf92vsepcth;
       public       postgres    false    209    213    2773            �
           2606    16999 &   user_roles fkh8ciramu9cc9q3qcqiv4ue8a6    FK CONSTRAINT     �   ALTER TABLE ONLY public.user_roles
    ADD CONSTRAINT fkh8ciramu9cc9q3qcqiv4ue8a6 FOREIGN KEY (role_id) REFERENCES public.roles(id);
 P   ALTER TABLE ONLY public.user_roles DROP CONSTRAINT fkh8ciramu9cc9q3qcqiv4ue8a6;
       public       postgres    false    211    2745    197            �
           2606    17004 &   user_roles fkhfh9dx7w3ubf1co1vdev94g3f    FK CONSTRAINT     �   ALTER TABLE ONLY public.user_roles
    ADD CONSTRAINT fkhfh9dx7w3ubf1co1vdev94g3f FOREIGN KEY (user_id) REFERENCES public.users(id);
 P   ALTER TABLE ONLY public.user_roles DROP CONSTRAINT fkhfh9dx7w3ubf1co1vdev94g3f;
       public       postgres    false    211    213    2773            �
           2606    16974 #   lessons fkl9690oj53p2iccg9njgkqfpk7    FK CONSTRAINT     �   ALTER TABLE ONLY public.lessons
    ADD CONSTRAINT fkl9690oj53p2iccg9njgkqfpk7 FOREIGN KEY (task_id) REFERENCES public.tasks(id);
 M   ALTER TABLE ONLY public.lessons DROP CONSTRAINT fkl9690oj53p2iccg9njgkqfpk7;
       public       postgres    false    209    203    2753            �
           2606    16994 *   user_languages fkt3sjkb7b30p03i378qdcr2s9k    FK CONSTRAINT     �   ALTER TABLE ONLY public.user_languages
    ADD CONSTRAINT fkt3sjkb7b30p03i378qdcr2s9k FOREIGN KEY (user_id) REFERENCES public.users(id);
 T   ALTER TABLE ONLY public.user_languages DROP CONSTRAINT fkt3sjkb7b30p03i378qdcr2s9k;
       public       postgres    false    210    2773    213            Z      x������ � �      `   *   x�3���K�I-�2�L-.H<�1?�˘31'571�+F��� �
`      d      x������ � �      b   D   x�3�,(��K�,�L�+I�2�LJ,�L��2���rSS2�L8��S�L9s��y�\1z\\\ ���      X   !   x�3���q�v�2��]|=��b���� t��      \      x������ � �      ^   6   x�3�,�ONL*�I,��2�L/J��M,�2�,.HM���K�2�,/�,�b���� ��4      e      x�3�4�4�b0i�i�ef��1z\\\ K3%      f      x�3�4�2bc ����� I      h     x���9o�0 ���
ր�Ɲ��I!W9T �B�!���B~}Q�dM�7>=}zt �'�L�."�
�а��U�
&"��U4�2VP-yK�(+�.����b7@t�5B�
�- ����tI�(�ր8׈u$:n�Ր��(��&�λ�n��קa�E6��W,U�����:���/�����r8���l���~�I������:1	�;%��I�Con�����6/zי9Q��OS��ŝw���԰�=��l��A��8n�;�>B�eA~rQ�~     