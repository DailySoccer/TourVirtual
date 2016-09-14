//
//  _MDPVideoPublicationChannelModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPVideoPublicationChannelModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPVideoPublicationChannelModelAttributes {
	__unsafe_unretained NSString *encrypted;
	__unsafe_unretained NSString *idVideoPublicationChannel;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *method;
	__unsafe_unretained NSString *url;
	__unsafe_unretained NSString *urlDash;
	__unsafe_unretained NSString *urlHDS;
	__unsafe_unretained NSString *urlHLS;
	__unsafe_unretained NSString *urlProgressive;
	__unsafe_unretained NSString *urlSmoothStreaming;
} MDPVideoPublicationChannelModelAttributes;

extern const struct MDPVideoPublicationChannelModelRelationships {
	__unsafe_unretained NSString *videoPublicationChannels;
} MDPVideoPublicationChannelModelRelationships;

extern const struct MDPVideoPublicationChannelModelUserInfo {
	__unsafe_unretained NSString *mappedKeyName;
} MDPVideoPublicationChannelModelUserInfo;

@class MDPVideoModel;

@interface _MDPVideoPublicationChannelModel : NSManagedObject

@property (nonatomic, strong) NSNumber* encrypted;

@property (atomic) BOOL encryptedValue;
- (BOOL)encryptedValue;
- (void)setEncryptedValue:(BOOL)value_;

//- (BOOL)validateEncrypted:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* idVideoPublicationChannel;

@property (atomic) int64_t idVideoPublicationChannelValue;
- (int64_t)idVideoPublicationChannelValue;
- (void)setIdVideoPublicationChannelValue:(int64_t)value_;

//- (BOOL)validateIdVideoPublicationChannel:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* method;

//- (BOOL)validateMethod:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* url;

//- (BOOL)validateUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* urlDash;

//- (BOOL)validateUrlDash:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* urlHDS;

//- (BOOL)validateUrlHDS:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* urlHLS;

//- (BOOL)validateUrlHLS:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* urlProgressive;

//- (BOOL)validateUrlProgressive:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* urlSmoothStreaming;

//- (BOOL)validateUrlSmoothStreaming:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *videoPublicationChannels;

- (NSMutableSet*)videoPublicationChannelsSet;

@end

@interface _MDPVideoPublicationChannelModel (VideoPublicationChannelsCoreDataGeneratedAccessors)
- (void)addVideoPublicationChannels:(NSSet*)value_;
- (void)removeVideoPublicationChannels:(NSSet*)value_;
- (void)addVideoPublicationChannelsObject:(MDPVideoModel*)value_;
- (void)removeVideoPublicationChannelsObject:(MDPVideoModel*)value_;
@end

@interface _MDPVideoPublicationChannelModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveEncrypted;
- (void)setPrimitiveEncrypted:(NSNumber*)value;

- (BOOL)primitiveEncryptedValue;
- (void)setPrimitiveEncryptedValue:(BOOL)value_;

- (NSNumber*)primitiveIdVideoPublicationChannel;
- (void)setPrimitiveIdVideoPublicationChannel:(NSNumber*)value;

- (int64_t)primitiveIdVideoPublicationChannelValue;
- (void)setPrimitiveIdVideoPublicationChannelValue:(int64_t)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveMethod;
- (void)setPrimitiveMethod:(NSString*)value;

- (NSString*)primitiveUrl;
- (void)setPrimitiveUrl:(NSString*)value;

- (NSString*)primitiveUrlDash;
- (void)setPrimitiveUrlDash:(NSString*)value;

- (NSString*)primitiveUrlHDS;
- (void)setPrimitiveUrlHDS:(NSString*)value;

- (NSString*)primitiveUrlHLS;
- (void)setPrimitiveUrlHLS:(NSString*)value;

- (NSString*)primitiveUrlProgressive;
- (void)setPrimitiveUrlProgressive:(NSString*)value;

- (NSString*)primitiveUrlSmoothStreaming;
- (void)setPrimitiveUrlSmoothStreaming:(NSString*)value;

- (NSMutableSet*)primitiveVideoPublicationChannels;
- (void)setPrimitiveVideoPublicationChannels:(NSMutableSet*)value;

@end
