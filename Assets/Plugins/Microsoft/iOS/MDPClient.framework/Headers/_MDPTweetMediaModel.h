//
//  _MDPTweetMediaModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPTweetMediaModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPTweetMediaModelAttributes {
	__unsafe_unretained NSString *displayUrl;
	__unsafe_unretained NSString *indices;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *mediaUrl;
} MDPTweetMediaModelAttributes;

extern const struct MDPTweetMediaModelRelationships {
	__unsafe_unretained NSString *tweetEntitiesMedia;
} MDPTweetMediaModelRelationships;

@class MDPTweetEntitiesModel;

@interface _MDPTweetMediaModel : NSManagedObject

@property (nonatomic, strong) NSString* displayUrl;

//- (BOOL)validateDisplayUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSData* indices;

//- (BOOL)validateIndices:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* mediaUrl;

//- (BOOL)validateMediaUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *tweetEntitiesMedia;

- (NSMutableSet*)tweetEntitiesMediaSet;

@end

@interface _MDPTweetMediaModel (TweetEntitiesMediaCoreDataGeneratedAccessors)
- (void)addTweetEntitiesMedia:(NSSet*)value_;
- (void)removeTweetEntitiesMedia:(NSSet*)value_;
- (void)addTweetEntitiesMediaObject:(MDPTweetEntitiesModel*)value_;
- (void)removeTweetEntitiesMediaObject:(MDPTweetEntitiesModel*)value_;
@end

@interface _MDPTweetMediaModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveDisplayUrl;
- (void)setPrimitiveDisplayUrl:(NSString*)value;

- (NSData*)primitiveIndices;
- (void)setPrimitiveIndices:(NSData*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveMediaUrl;
- (void)setPrimitiveMediaUrl:(NSString*)value;

- (NSMutableSet*)primitiveTweetEntitiesMedia;
- (void)setPrimitiveTweetEntitiesMedia:(NSMutableSet*)value;

@end
