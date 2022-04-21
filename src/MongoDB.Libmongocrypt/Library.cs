using System;
using System.Runtime.InteropServices;

namespace MongoDB.Libmongocrypt
{
    public class Library
    {
        private static readonly Lazy<LibraryLoader> __loader = new Lazy<LibraryLoader>((Func<LibraryLoader>)(() => new LibraryLoader()), true);
        private static readonly Lazy<Library.Delegates.mongocrypt_version> _mongocrypt_version = new Lazy<Library.Delegates.mongocrypt_version>((Func<Library.Delegates.mongocrypt_version>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_version>(nameof(mongocrypt_version))), true);
        private static readonly Lazy<Library.Delegates.mongocrypt_new> _mongocrypt_new = new Lazy<Library.Delegates.mongocrypt_new>((Func<Library.Delegates.mongocrypt_new>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_new>(nameof(mongocrypt_new))), true);
        private static readonly Lazy<Library.Delegates.mongocrypt_setopt_log_handler> _mongocrypt_setopt_log_handler;
        private static readonly Lazy<Library.Delegates.mongocrypt_setopt_kms_providers> _mongocrypt_setopt_kms_providers;
        private static readonly Lazy<Library.Delegates.mongocrypt_ctx_setopt_key_encryption_key> _mongocrypt_ctx_setopt_key_encryption_key;
        private static readonly Lazy<Library.Delegates.mongocrypt_setopt_crypto_hooks> _mongocrypt_setopt_crypto_hooks;
        private static readonly Lazy<Library.Delegates.mongocrypt_setopt_crypto_hook_sign_rsaes_pkcs1_v1_5> _mongocrypt_setopt_crypto_hook_sign_rsaes_pkcs1_v1_5;
        private static readonly Lazy<Library.Delegates.mongocrypt_setopt_schema_map> _mongocrypt_setopt_schema_map;
        private static readonly Lazy<Library.Delegates.mongocrypt_init> _mongocrypt_init = new Lazy<Library.Delegates.mongocrypt_init>((Func<Library.Delegates.mongocrypt_init>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_init>(nameof(mongocrypt_init))), true);
        private static readonly Lazy<Library.Delegates.mongocrypt_destroy> _mongocrypt_destroy = new Lazy<Library.Delegates.mongocrypt_destroy>((Func<Library.Delegates.mongocrypt_destroy>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_destroy>(nameof(mongocrypt_destroy))), true);
        private static readonly Lazy<Library.Delegates.mongocrypt_status> _mongocrypt_status = new Lazy<Library.Delegates.mongocrypt_status>((Func<Library.Delegates.mongocrypt_status>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_status>(nameof(mongocrypt_status))), true);
        private static readonly Lazy<Library.Delegates.mongocrypt_status_new> _mongocrypt_status_new;
        private static readonly Lazy<Library.Delegates.mongocrypt_status_destroy> _mongocrypt_status_destroy;
        private static readonly Lazy<Library.Delegates.mongocrypt_status_type> _mongocrypt_status_type;
        private static readonly Lazy<Library.Delegates.mongocrypt_status_code> _mongocrypt_status_code;
        private static readonly Lazy<Library.Delegates.mongocrypt_status_message> _mongocrypt_status_message;
        private static readonly Lazy<Library.Delegates.mongocrypt_status_ok> _mongocrypt_status_ok;
        private static readonly Lazy<Library.Delegates.mongocrypt_status_set> _mongocrypt_status_set;
        private static readonly Lazy<Library.Delegates.mongocrypt_binary_new> _mongocrypt_binary_new;
        private static readonly Lazy<Library.Delegates.mongocrypt_binary_destroy> _mongocrypt_binary_destroy;
        private static readonly Lazy<Library.Delegates.mongocrypt_binary_new_from_data> _mongocrypt_binary_new_from_data;
        private static readonly Lazy<Library.Delegates.mongocrypt_binary_data> _mongocrypt_binary_data;
        private static readonly Lazy<Library.Delegates.mongocrypt_binary_len> _mongocrypt_binary_len;
        private static readonly Lazy<Library.Delegates.mongocrypt_ctx_new> _mongocrypt_ctx_new;
        private static readonly Lazy<Library.Delegates.mongocrypt_ctx_setopt_masterkey_aws> _mongocrypt_ctx_setopt_masterkey_aws;
        private static readonly Lazy<Library.Delegates.mongocrypt_ctx_setopt_masterkey_aws_endpoint> _mongocrypt_ctx_setopt_masterkey_aws_endpoint;
        private static readonly Lazy<Library.Delegates.mongocrypt_ctx_status> _mongocrypt_ctx_status;
        private static readonly Lazy<Library.Delegates.mongocrypt_ctx_encrypt_init> _mongocrypt_ctx_encrypt_init;
        private static readonly Lazy<Library.Delegates.mongocrypt_ctx_decrypt_init> _mongocrypt_ctx_decrypt_init;
        private static readonly Lazy<Library.Delegates.mongocrypt_ctx_explicit_encrypt_init> _mongocrypt_ctx_explicit_encrypt_init;
        private static readonly Lazy<Library.Delegates.mongocrypt_ctx_explicit_decrypt_init> _mongocrypt_ctx_explicit_decrypt_init;
        private static readonly Lazy<Library.Delegates.mongocrypt_ctx_datakey_init> _mongocrypt_ctx_datakey_init;
        private static readonly Lazy<Library.Delegates.mongocrypt_ctx_setopt_masterkey_local> _mongocrypt_ctx_setopt_masterkey_local;
        private static readonly Lazy<Library.Delegates.mongocrypt_ctx_setopt_key_id> _mongocrypt_ctx_setopt_key_id;
        private static readonly Lazy<Library.Delegates.mongocrypt_ctx_setopt_key_alt_name> _mongocrypt_ctx_setopt_key_alt_name;
        private static readonly Lazy<Library.Delegates.mongocrypt_ctx_setopt_algorithm> _mongocrypt_ctx_setopt_algorithm;
        private static readonly Lazy<Library.Delegates.mongocrypt_ctx_state> _mongocrypt_ctx_state;
        private static readonly Lazy<Library.Delegates.mongocrypt_ctx_mongo_op> _mongocrypt_ctx_mongo_op;
        private static readonly Lazy<Library.Delegates.mongocrypt_ctx_mongo_feed> _mongocrypt_ctx_mongo_feed;
        private static readonly Lazy<Library.Delegates.mongocrypt_ctx_mongo_done> _mongocrypt_ctx_mongo_done;
        private static readonly Lazy<Library.Delegates.mongocrypt_ctx_next_kms_ctx> _mongocrypt_ctx_next_kms_ctx;
        private static readonly Lazy<Library.Delegates.mongocrypt_kms_ctx_endpoint> _mongocrypt_kms_ctx_endpoint;
        private static readonly Lazy<Library.Delegates.mongocrypt_kms_ctx_message> _mongocrypt_kms_ctx_message;
        private static readonly Lazy<Library.Delegates.mongocrypt_kms_ctx_bytes_needed> _mongocrypt_kms_ctx_bytes_needed;
        private static readonly Lazy<Library.Delegates.mongocrypt_kms_ctx_feed> _mongocrypt_kms_ctx_feed;
        private static readonly Lazy<Library.Delegates.mongocrypt_kms_ctx_status> _mongocrypt_kms_ctx_status;
        private static readonly Lazy<Library.Delegates.mongocrypt_ctx_kms_done> _mongocrypt_ctx_kms_done;
        private static readonly Lazy<Library.Delegates.mongocrypt_ctx_finalize> _mongocrypt_ctx_finalize;
        private static readonly Lazy<Library.Delegates.mongocrypt_ctx_destroy> _mongocrypt_ctx_destroy;
        private static readonly Lazy<Library.Delegates.mongocrypt_kms_ctx_get_kms_provider> _mongocrypt_kms_ctx_get_kms_provider;

        static Library()
        {
            Library._mongocrypt_setopt_kms_providers = new Lazy<Library.Delegates.mongocrypt_setopt_kms_providers>((Func<Library.Delegates.mongocrypt_setopt_kms_providers>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_setopt_kms_providers>(nameof(mongocrypt_setopt_kms_providers))), true);
            Library._mongocrypt_ctx_setopt_key_encryption_key = new Lazy<Library.Delegates.mongocrypt_ctx_setopt_key_encryption_key>((Func<Library.Delegates.mongocrypt_ctx_setopt_key_encryption_key>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_ctx_setopt_key_encryption_key>(nameof(mongocrypt_ctx_setopt_key_encryption_key))), true);
            Library._mongocrypt_setopt_crypto_hooks = new Lazy<Library.Delegates.mongocrypt_setopt_crypto_hooks>((Func<Library.Delegates.mongocrypt_setopt_crypto_hooks>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_setopt_crypto_hooks>(nameof(mongocrypt_setopt_crypto_hooks))), true);
            Library._mongocrypt_setopt_crypto_hook_sign_rsaes_pkcs1_v1_5 = new Lazy<Library.Delegates.mongocrypt_setopt_crypto_hook_sign_rsaes_pkcs1_v1_5>((Func<Library.Delegates.mongocrypt_setopt_crypto_hook_sign_rsaes_pkcs1_v1_5>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_setopt_crypto_hook_sign_rsaes_pkcs1_v1_5>(nameof(mongocrypt_setopt_crypto_hook_sign_rsaes_pkcs1_v1_5))), true);
            Library._mongocrypt_setopt_log_handler = new Lazy<Library.Delegates.mongocrypt_setopt_log_handler>((Func<Library.Delegates.mongocrypt_setopt_log_handler>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_setopt_log_handler>(nameof(mongocrypt_setopt_log_handler))), true);
            Library._mongocrypt_setopt_schema_map = new Lazy<Library.Delegates.mongocrypt_setopt_schema_map>((Func<Library.Delegates.mongocrypt_setopt_schema_map>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_setopt_schema_map>(nameof(mongocrypt_setopt_schema_map))), true);
            Library._mongocrypt_status_new = new Lazy<Library.Delegates.mongocrypt_status_new>((Func<Library.Delegates.mongocrypt_status_new>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_status_new>(nameof(mongocrypt_status_new))), true);
            Library._mongocrypt_status_destroy = new Lazy<Library.Delegates.mongocrypt_status_destroy>((Func<Library.Delegates.mongocrypt_status_destroy>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_status_destroy>(nameof(mongocrypt_status_destroy))), true);
            Library._mongocrypt_status_type = new Lazy<Library.Delegates.mongocrypt_status_type>((Func<Library.Delegates.mongocrypt_status_type>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_status_type>(nameof(mongocrypt_status_type))), true);
            Library._mongocrypt_status_code = new Lazy<Library.Delegates.mongocrypt_status_code>((Func<Library.Delegates.mongocrypt_status_code>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_status_code>(nameof(mongocrypt_status_code))), true);
            Library._mongocrypt_status_message = new Lazy<Library.Delegates.mongocrypt_status_message>((Func<Library.Delegates.mongocrypt_status_message>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_status_message>(nameof(mongocrypt_status_message))), true);
            Library._mongocrypt_status_ok = new Lazy<Library.Delegates.mongocrypt_status_ok>((Func<Library.Delegates.mongocrypt_status_ok>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_status_ok>(nameof(mongocrypt_status_ok))), true);
            Library._mongocrypt_status_set = new Lazy<Library.Delegates.mongocrypt_status_set>((Func<Library.Delegates.mongocrypt_status_set>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_status_set>(nameof(mongocrypt_status_set))), true);
            Library._mongocrypt_binary_new = new Lazy<Library.Delegates.mongocrypt_binary_new>((Func<Library.Delegates.mongocrypt_binary_new>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_binary_new>(nameof(mongocrypt_binary_new))), true);
            Library._mongocrypt_binary_destroy = new Lazy<Library.Delegates.mongocrypt_binary_destroy>((Func<Library.Delegates.mongocrypt_binary_destroy>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_binary_destroy>(nameof(mongocrypt_binary_destroy))), true);
            Library._mongocrypt_binary_new_from_data = new Lazy<Library.Delegates.mongocrypt_binary_new_from_data>((Func<Library.Delegates.mongocrypt_binary_new_from_data>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_binary_new_from_data>(nameof(mongocrypt_binary_new_from_data))), true);
            Library._mongocrypt_binary_data = new Lazy<Library.Delegates.mongocrypt_binary_data>((Func<Library.Delegates.mongocrypt_binary_data>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_binary_data>(nameof(mongocrypt_binary_data))), true);
            Library._mongocrypt_binary_len = new Lazy<Library.Delegates.mongocrypt_binary_len>((Func<Library.Delegates.mongocrypt_binary_len>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_binary_len>(nameof(mongocrypt_binary_len))), true);
            Library._mongocrypt_ctx_new = new Lazy<Library.Delegates.mongocrypt_ctx_new>((Func<Library.Delegates.mongocrypt_ctx_new>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_ctx_new>(nameof(mongocrypt_ctx_new))), true);
            Library._mongocrypt_ctx_setopt_masterkey_aws = new Lazy<Library.Delegates.mongocrypt_ctx_setopt_masterkey_aws>((Func<Library.Delegates.mongocrypt_ctx_setopt_masterkey_aws>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_ctx_setopt_masterkey_aws>(nameof(mongocrypt_ctx_setopt_masterkey_aws))), true);
            Library._mongocrypt_ctx_setopt_masterkey_aws_endpoint = new Lazy<Library.Delegates.mongocrypt_ctx_setopt_masterkey_aws_endpoint>((Func<Library.Delegates.mongocrypt_ctx_setopt_masterkey_aws_endpoint>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_ctx_setopt_masterkey_aws_endpoint>(nameof(mongocrypt_ctx_setopt_masterkey_aws_endpoint))), true);
            Library._mongocrypt_ctx_setopt_masterkey_local = new Lazy<Library.Delegates.mongocrypt_ctx_setopt_masterkey_local>((Func<Library.Delegates.mongocrypt_ctx_setopt_masterkey_local>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_ctx_setopt_masterkey_local>(nameof(mongocrypt_ctx_setopt_masterkey_local))), true);
            Library._mongocrypt_ctx_setopt_key_alt_name = new Lazy<Library.Delegates.mongocrypt_ctx_setopt_key_alt_name>((Func<Library.Delegates.mongocrypt_ctx_setopt_key_alt_name>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_ctx_setopt_key_alt_name>(nameof(mongocrypt_ctx_setopt_key_alt_name))), true);
            Library._mongocrypt_ctx_setopt_key_id = new Lazy<Library.Delegates.mongocrypt_ctx_setopt_key_id>((Func<Library.Delegates.mongocrypt_ctx_setopt_key_id>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_ctx_setopt_key_id>(nameof(mongocrypt_ctx_setopt_key_id))), true);
            Library._mongocrypt_ctx_setopt_algorithm = new Lazy<Library.Delegates.mongocrypt_ctx_setopt_algorithm>((Func<Library.Delegates.mongocrypt_ctx_setopt_algorithm>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_ctx_setopt_algorithm>(nameof(mongocrypt_ctx_setopt_algorithm))), true);
            Library._mongocrypt_ctx_status = new Lazy<Library.Delegates.mongocrypt_ctx_status>((Func<Library.Delegates.mongocrypt_ctx_status>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_ctx_status>(nameof(mongocrypt_ctx_status))), true);
            Library._mongocrypt_ctx_encrypt_init = new Lazy<Library.Delegates.mongocrypt_ctx_encrypt_init>((Func<Library.Delegates.mongocrypt_ctx_encrypt_init>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_ctx_encrypt_init>(nameof(mongocrypt_ctx_encrypt_init))), true);
            Library._mongocrypt_ctx_decrypt_init = new Lazy<Library.Delegates.mongocrypt_ctx_decrypt_init>((Func<Library.Delegates.mongocrypt_ctx_decrypt_init>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_ctx_decrypt_init>(nameof(mongocrypt_ctx_decrypt_init))), true);
            Library._mongocrypt_ctx_explicit_encrypt_init = new Lazy<Library.Delegates.mongocrypt_ctx_explicit_encrypt_init>((Func<Library.Delegates.mongocrypt_ctx_explicit_encrypt_init>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_ctx_explicit_encrypt_init>(nameof(mongocrypt_ctx_explicit_encrypt_init))), true);
            Library._mongocrypt_ctx_explicit_decrypt_init = new Lazy<Library.Delegates.mongocrypt_ctx_explicit_decrypt_init>((Func<Library.Delegates.mongocrypt_ctx_explicit_decrypt_init>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_ctx_explicit_decrypt_init>(nameof(mongocrypt_ctx_explicit_decrypt_init))), true);
            Library._mongocrypt_ctx_datakey_init = new Lazy<Library.Delegates.mongocrypt_ctx_datakey_init>((Func<Library.Delegates.mongocrypt_ctx_datakey_init>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_ctx_datakey_init>(nameof(mongocrypt_ctx_datakey_init))), true);
            Library._mongocrypt_ctx_state = new Lazy<Library.Delegates.mongocrypt_ctx_state>((Func<Library.Delegates.mongocrypt_ctx_state>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_ctx_state>(nameof(mongocrypt_ctx_state))), true);
            Library._mongocrypt_ctx_mongo_op = new Lazy<Library.Delegates.mongocrypt_ctx_mongo_op>((Func<Library.Delegates.mongocrypt_ctx_mongo_op>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_ctx_mongo_op>(nameof(mongocrypt_ctx_mongo_op))), true);
            Library._mongocrypt_ctx_mongo_feed = new Lazy<Library.Delegates.mongocrypt_ctx_mongo_feed>((Func<Library.Delegates.mongocrypt_ctx_mongo_feed>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_ctx_mongo_feed>(nameof(mongocrypt_ctx_mongo_feed))), true);
            Library._mongocrypt_ctx_mongo_done = new Lazy<Library.Delegates.mongocrypt_ctx_mongo_done>((Func<Library.Delegates.mongocrypt_ctx_mongo_done>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_ctx_mongo_done>(nameof(mongocrypt_ctx_mongo_done))), true);
            Library._mongocrypt_ctx_next_kms_ctx = new Lazy<Library.Delegates.mongocrypt_ctx_next_kms_ctx>((Func<Library.Delegates.mongocrypt_ctx_next_kms_ctx>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_ctx_next_kms_ctx>(nameof(mongocrypt_ctx_next_kms_ctx))), true);
            Library._mongocrypt_kms_ctx_endpoint = new Lazy<Library.Delegates.mongocrypt_kms_ctx_endpoint>((Func<Library.Delegates.mongocrypt_kms_ctx_endpoint>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_kms_ctx_endpoint>(nameof(mongocrypt_kms_ctx_endpoint))), true);
            Library._mongocrypt_kms_ctx_message = new Lazy<Library.Delegates.mongocrypt_kms_ctx_message>((Func<Library.Delegates.mongocrypt_kms_ctx_message>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_kms_ctx_message>(nameof(mongocrypt_kms_ctx_message))), true);
            Library._mongocrypt_kms_ctx_bytes_needed = new Lazy<Library.Delegates.mongocrypt_kms_ctx_bytes_needed>((Func<Library.Delegates.mongocrypt_kms_ctx_bytes_needed>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_kms_ctx_bytes_needed>(nameof(mongocrypt_kms_ctx_bytes_needed))), true);
            Library._mongocrypt_kms_ctx_feed = new Lazy<Library.Delegates.mongocrypt_kms_ctx_feed>((Func<Library.Delegates.mongocrypt_kms_ctx_feed>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_kms_ctx_feed>(nameof(mongocrypt_kms_ctx_feed))), true);
            Library._mongocrypt_kms_ctx_status = new Lazy<Library.Delegates.mongocrypt_kms_ctx_status>((Func<Library.Delegates.mongocrypt_kms_ctx_status>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_kms_ctx_status>(nameof(mongocrypt_kms_ctx_status))), true);
            Library._mongocrypt_ctx_kms_done = new Lazy<Library.Delegates.mongocrypt_ctx_kms_done>((Func<Library.Delegates.mongocrypt_ctx_kms_done>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_ctx_kms_done>(nameof(mongocrypt_ctx_kms_done))), true);
            Library._mongocrypt_ctx_finalize = new Lazy<Library.Delegates.mongocrypt_ctx_finalize>((Func<Library.Delegates.mongocrypt_ctx_finalize>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_ctx_finalize>(nameof(mongocrypt_ctx_finalize))), true);
            Library._mongocrypt_ctx_destroy = new Lazy<Library.Delegates.mongocrypt_ctx_destroy>((Func<Library.Delegates.mongocrypt_ctx_destroy>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_ctx_destroy>(nameof(mongocrypt_ctx_destroy))), true);
            Library._mongocrypt_kms_ctx_get_kms_provider = new Lazy<Library.Delegates.mongocrypt_kms_ctx_get_kms_provider>((Func<Library.Delegates.mongocrypt_kms_ctx_get_kms_provider>)(() => Library.__loader.Value.GetFunction<Library.Delegates.mongocrypt_kms_ctx_get_kms_provider>(nameof(mongocrypt_kms_ctx_get_kms_provider))), true);
        }

        public static string Version
        {
            get
            {
                uint length;
                return Marshal.PtrToStringAnsi(Library.mongocrypt_version(out length));
            }
        }

        internal static Library.Delegates.mongocrypt_version mongocrypt_version => Library._mongocrypt_version.Value;

        internal static Library.Delegates.mongocrypt_new mongocrypt_new => Library._mongocrypt_new.Value;

        internal static Library.Delegates.mongocrypt_setopt_log_handler mongocrypt_setopt_log_handler => Library._mongocrypt_setopt_log_handler.Value;

        internal static Library.Delegates.mongocrypt_setopt_kms_providers mongocrypt_setopt_kms_providers => Library._mongocrypt_setopt_kms_providers.Value;

        internal static Library.Delegates.mongocrypt_ctx_setopt_key_encryption_key mongocrypt_ctx_setopt_key_encryption_key => Library._mongocrypt_ctx_setopt_key_encryption_key.Value;

        internal static Library.Delegates.mongocrypt_setopt_crypto_hooks mongocrypt_setopt_crypto_hooks => Library._mongocrypt_setopt_crypto_hooks.Value;

        internal static Library.Delegates.mongocrypt_setopt_crypto_hook_sign_rsaes_pkcs1_v1_5 mongocrypt_setopt_crypto_hook_sign_rsaes_pkcs1_v1_5 => Library._mongocrypt_setopt_crypto_hook_sign_rsaes_pkcs1_v1_5.Value;

        internal static Library.Delegates.mongocrypt_setopt_schema_map mongocrypt_setopt_schema_map => Library._mongocrypt_setopt_schema_map.Value;

        internal static Library.Delegates.mongocrypt_init mongocrypt_init => Library._mongocrypt_init.Value;

        internal static Library.Delegates.mongocrypt_destroy mongocrypt_destroy => Library._mongocrypt_destroy.Value;

        internal static Library.Delegates.mongocrypt_status mongocrypt_status => Library._mongocrypt_status.Value;

        internal static Library.Delegates.mongocrypt_status_new mongocrypt_status_new => Library._mongocrypt_status_new.Value;

        internal static Library.Delegates.mongocrypt_status_destroy mongocrypt_status_destroy => Library._mongocrypt_status_destroy.Value;

        internal static Library.Delegates.mongocrypt_status_type mongocrypt_status_type => Library._mongocrypt_status_type.Value;

        internal static Library.Delegates.mongocrypt_status_code mongocrypt_status_code => Library._mongocrypt_status_code.Value;

        internal static Library.Delegates.mongocrypt_status_message mongocrypt_status_message => Library._mongocrypt_status_message.Value;

        internal static Library.Delegates.mongocrypt_status_ok mongocrypt_status_ok => Library._mongocrypt_status_ok.Value;

        internal static Library.Delegates.mongocrypt_status_set mongocrypt_status_set => Library._mongocrypt_status_set.Value;

        internal static Library.Delegates.mongocrypt_binary_new mongocrypt_binary_new => Library._mongocrypt_binary_new.Value;

        internal static Library.Delegates.mongocrypt_binary_destroy mongocrypt_binary_destroy => Library._mongocrypt_binary_destroy.Value;

        internal static Library.Delegates.mongocrypt_binary_new_from_data mongocrypt_binary_new_from_data => Library._mongocrypt_binary_new_from_data.Value;

        internal static Library.Delegates.mongocrypt_binary_data mongocrypt_binary_data => Library._mongocrypt_binary_data.Value;

        internal static Library.Delegates.mongocrypt_binary_len mongocrypt_binary_len => Library._mongocrypt_binary_len.Value;

        internal static Library.Delegates.mongocrypt_ctx_new mongocrypt_ctx_new => Library._mongocrypt_ctx_new.Value;

        internal static Library.Delegates.mongocrypt_ctx_setopt_masterkey_aws mongocrypt_ctx_setopt_masterkey_aws => Library._mongocrypt_ctx_setopt_masterkey_aws.Value;

        internal static Library.Delegates.mongocrypt_ctx_setopt_masterkey_aws_endpoint mongocrypt_ctx_setopt_masterkey_aws_endpoint => Library._mongocrypt_ctx_setopt_masterkey_aws_endpoint.Value;

        internal static Library.Delegates.mongocrypt_ctx_status mongocrypt_ctx_status => Library._mongocrypt_ctx_status.Value;

        internal static Library.Delegates.mongocrypt_ctx_encrypt_init mongocrypt_ctx_encrypt_init => Library._mongocrypt_ctx_encrypt_init.Value;

        internal static Library.Delegates.mongocrypt_ctx_decrypt_init mongocrypt_ctx_decrypt_init => Library._mongocrypt_ctx_decrypt_init.Value;

        internal static Library.Delegates.mongocrypt_ctx_explicit_encrypt_init mongocrypt_ctx_explicit_encrypt_init => Library._mongocrypt_ctx_explicit_encrypt_init.Value;

        internal static Library.Delegates.mongocrypt_ctx_explicit_decrypt_init mongocrypt_ctx_explicit_decrypt_init => Library._mongocrypt_ctx_explicit_decrypt_init.Value;

        internal static Library.Delegates.mongocrypt_ctx_datakey_init mongocrypt_ctx_datakey_init => Library._mongocrypt_ctx_datakey_init.Value;

        internal static Library.Delegates.mongocrypt_ctx_setopt_masterkey_local mongocrypt_ctx_setopt_masterkey_local => Library._mongocrypt_ctx_setopt_masterkey_local.Value;

        internal static Library.Delegates.mongocrypt_ctx_setopt_key_id mongocrypt_ctx_setopt_key_id => Library._mongocrypt_ctx_setopt_key_id.Value;

        internal static Library.Delegates.mongocrypt_ctx_setopt_key_alt_name mongocrypt_ctx_setopt_key_alt_name => Library._mongocrypt_ctx_setopt_key_alt_name.Value;

        internal static Library.Delegates.mongocrypt_ctx_setopt_algorithm mongocrypt_ctx_setopt_algorithm => Library._mongocrypt_ctx_setopt_algorithm.Value;

        internal static Library.Delegates.mongocrypt_ctx_state mongocrypt_ctx_state => Library._mongocrypt_ctx_state.Value;

        internal static Library.Delegates.mongocrypt_ctx_mongo_op mongocrypt_ctx_mongo_op => Library._mongocrypt_ctx_mongo_op.Value;

        internal static Library.Delegates.mongocrypt_ctx_mongo_feed mongocrypt_ctx_mongo_feed => Library._mongocrypt_ctx_mongo_feed.Value;

        internal static Library.Delegates.mongocrypt_ctx_mongo_done mongocrypt_ctx_mongo_done => Library._mongocrypt_ctx_mongo_done.Value;

        internal static Library.Delegates.mongocrypt_ctx_next_kms_ctx mongocrypt_ctx_next_kms_ctx => Library._mongocrypt_ctx_next_kms_ctx.Value;

        internal static Library.Delegates.mongocrypt_kms_ctx_endpoint mongocrypt_kms_ctx_endpoint => Library._mongocrypt_kms_ctx_endpoint.Value;

        internal static Library.Delegates.mongocrypt_kms_ctx_message mongocrypt_kms_ctx_message => Library._mongocrypt_kms_ctx_message.Value;

        internal static Library.Delegates.mongocrypt_kms_ctx_bytes_needed mongocrypt_kms_ctx_bytes_needed => Library._mongocrypt_kms_ctx_bytes_needed.Value;

        internal static Library.Delegates.mongocrypt_kms_ctx_feed mongocrypt_kms_ctx_feed => Library._mongocrypt_kms_ctx_feed.Value;

        internal static Library.Delegates.mongocrypt_kms_ctx_status mongocrypt_kms_ctx_status => Library._mongocrypt_kms_ctx_status.Value;

        internal static Library.Delegates.mongocrypt_ctx_kms_done mongocrypt_ctx_kms_done => Library._mongocrypt_ctx_kms_done.Value;

        internal static Library.Delegates.mongocrypt_ctx_finalize mongocrypt_ctx_finalize => Library._mongocrypt_ctx_finalize.Value;

        internal static Library.Delegates.mongocrypt_ctx_destroy mongocrypt_ctx_destroy => Library._mongocrypt_ctx_destroy.Value;

        internal static Library.Delegates.mongocrypt_kms_ctx_get_kms_provider mongocrypt_kms_ctx_get_kms_provider => Library._mongocrypt_kms_ctx_get_kms_provider.Value;

        internal enum StatusType
        {
            MONGOCRYPT_STATUS_OK,
            MONGOCRYPT_STATUS_ERROR_CLIENT,
            MONGOCRYPT_STATUS_ERROR_KMS,
        }

        internal class Delegates
        {
            public delegate IntPtr mongocrypt_version(out uint length);

            public delegate MongoCryptSafeHandle mongocrypt_new();

            public delegate void LogCallback(
              [MarshalAs(UnmanagedType.I4)] LogLevel level,
              IntPtr messasge,
              uint message_length,
              IntPtr context);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_setopt_log_handler(
              MongoCryptSafeHandle handle,
              [MarshalAs(UnmanagedType.FunctionPtr)] Library.Delegates.LogCallback log_fn,
              IntPtr log_ctx);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_setopt_kms_providers(
              MongoCryptSafeHandle handle,
              BinarySafeHandle kms_providers);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_ctx_setopt_key_encryption_key(
              ContextSafeHandle handle,
              BinarySafeHandle bin);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool HashCallback(IntPtr ctx, IntPtr @in, IntPtr @out, IntPtr status);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool CryptoHmacCallback(
              IntPtr ctx,
              IntPtr key,
              IntPtr @in,
              IntPtr @out,
              IntPtr status);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool CryptoCallback(
              IntPtr ctx,
              IntPtr key,
              IntPtr iv,
              IntPtr @in,
              IntPtr @out,
              ref uint bytes_written,
              IntPtr status);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool RandomCallback(IntPtr ctx, IntPtr @out, uint count, IntPtr statusPtr);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_setopt_crypto_hooks(
              MongoCryptSafeHandle handle,
              [MarshalAs(UnmanagedType.FunctionPtr)] Library.Delegates.CryptoCallback aes_256_cbc_encrypt,
              [MarshalAs(UnmanagedType.FunctionPtr)] Library.Delegates.CryptoCallback aes_256_cbc_decrypt,
              [MarshalAs(UnmanagedType.FunctionPtr)] Library.Delegates.RandomCallback random,
              [MarshalAs(UnmanagedType.FunctionPtr)] Library.Delegates.CryptoHmacCallback hmac_sha_512,
              [MarshalAs(UnmanagedType.FunctionPtr)] Library.Delegates.CryptoHmacCallback hmac_sha_256,
              [MarshalAs(UnmanagedType.FunctionPtr)] Library.Delegates.HashCallback mongocrypt_hash_fn,
              IntPtr ctx);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_setopt_crypto_hook_sign_rsaes_pkcs1_v1_5(
              MongoCryptSafeHandle handle,
              [MarshalAs(UnmanagedType.FunctionPtr)] Library.Delegates.CryptoHmacCallback sign_rsaes_pkcs1_v1_5,
              IntPtr sign_ctx);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_setopt_schema_map(
              MongoCryptSafeHandle handle,
              BinarySafeHandle schema);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_init(MongoCryptSafeHandle handle);

            public delegate void mongocrypt_destroy(IntPtr ptr);

            public delegate bool mongocrypt_status(MongoCryptSafeHandle handle, StatusSafeHandle ptr);

            public delegate StatusSafeHandle mongocrypt_status_new();

            public delegate void mongocrypt_status_destroy(IntPtr ptr);

            public delegate Library.StatusType mongocrypt_status_type(StatusSafeHandle ptr);

            public delegate uint mongocrypt_status_code(StatusSafeHandle ptr);

            public delegate IntPtr mongocrypt_status_message(StatusSafeHandle ptr, out uint length);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_status_ok(StatusSafeHandle ptr);

            public delegate void mongocrypt_status_set(
              StatusSafeHandle ptr,
              int type,
              uint code,
              IntPtr msg,
              int length);

            public delegate BinarySafeHandle mongocrypt_binary_new();

            public delegate void mongocrypt_binary_destroy(IntPtr ptr);

            public delegate BinarySafeHandle mongocrypt_binary_new_from_data(
              IntPtr ptr,
              uint len);

            public delegate IntPtr mongocrypt_binary_data(BinarySafeHandle handle);

            public delegate uint mongocrypt_binary_len(BinarySafeHandle handle);

            public delegate ContextSafeHandle mongocrypt_ctx_new(
              MongoCryptSafeHandle handle);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_ctx_setopt_masterkey_aws(
              ContextSafeHandle handle,
              IntPtr region,
              int region_len,
              IntPtr cmk,
              int cmk_len);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_ctx_setopt_masterkey_aws_endpoint(
              ContextSafeHandle handle,
              IntPtr endpoint,
              int endpoint_len);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_ctx_status(ContextSafeHandle handle, StatusSafeHandle status);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_ctx_encrypt_init(
              ContextSafeHandle handle,
              IntPtr ns,
              int length,
              BinarySafeHandle binary);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_ctx_decrypt_init(
              ContextSafeHandle handle,
              BinarySafeHandle binary);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_ctx_explicit_encrypt_init(
              ContextSafeHandle handle,
              BinarySafeHandle binary);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_ctx_explicit_decrypt_init(
              ContextSafeHandle handle,
              BinarySafeHandle binary);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_ctx_datakey_init(ContextSafeHandle handle);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_ctx_setopt_schema_map(
              ContextSafeHandle handle,
              BinarySafeHandle binary);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_ctx_setopt_masterkey_local(ContextSafeHandle handle);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_ctx_setopt_key_alt_name(
              ContextSafeHandle handle,
              BinarySafeHandle binary);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_ctx_setopt_key_id(
              ContextSafeHandle handle,
              BinarySafeHandle binary);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_ctx_setopt_algorithm(
              ContextSafeHandle handle,
              [MarshalAs(UnmanagedType.LPStr)] string algorithm,
              int length);

            public delegate CryptContext.StateCode mongocrypt_ctx_state(
              ContextSafeHandle handle);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_ctx_mongo_op(
              ContextSafeHandle handle,
              BinarySafeHandle bsonOp);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_ctx_mongo_feed(
              ContextSafeHandle handle,
              BinarySafeHandle reply);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_ctx_mongo_done(ContextSafeHandle handle);

            public delegate IntPtr mongocrypt_ctx_next_kms_ctx(ContextSafeHandle handle);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_kms_ctx_endpoint(IntPtr handle, ref IntPtr endpoint);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_kms_ctx_message(IntPtr handle, BinarySafeHandle binary);

            public delegate uint mongocrypt_kms_ctx_bytes_needed(IntPtr handle);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_kms_ctx_feed(IntPtr handle, BinarySafeHandle binary);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_kms_ctx_status(IntPtr handle, StatusSafeHandle status);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_ctx_kms_done(ContextSafeHandle handle);

            [return: MarshalAs(UnmanagedType.I1)]
            public delegate bool mongocrypt_ctx_finalize(
              ContextSafeHandle handle,
              BinarySafeHandle binary);

            public delegate void mongocrypt_ctx_destroy(IntPtr ptr);

            public delegate IntPtr mongocrypt_kms_ctx_get_kms_provider(
              IntPtr handle,
              out uint length);
        }
    }
}
