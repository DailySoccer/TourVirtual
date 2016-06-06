//
//  _MDPTweetUrlModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPTweetUrlModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPTweetUrlModelAttributes {
	__unsafe_unretained NSString *displayUrl;
	__unsafe_unretained NSString *indices;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *urlAddress;
} MDPTweetUrlModelAttributes;

extern const struct MDPTweetUrlModelRelationships {
	__unsafe_unretained NSString *tweetEntitiesUrls;
} MDPTweetUrlModelRelationships;

@class MDPTweetEntitiesModel;

@interface _MDPTweetUrlModel : NSManagedObject

@property (nonatomic, strong) NSString* displayUrl;

//- (BOOL)validateDisplayUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSData* indices;

//- (BOOL)validateIndices:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* urlAddress;

//- (BOOL)validateUrlAddress:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *tweetEntitiesUrls;

- (NSMutableSet*)tweetEntitiesUrlsSet;

@end

@interface _MDPTweetUrlModel (TweetEntitiesUrlsCoreDataGeneratedAccessors)
- (void)addTweetEntitiesUrls:(NSSet*)value_;
- (void)removeTweetEntitiesUrls:(NSSet*)value_;
- (void)addTweetEntitiesUrlsObject:(MDPTweetEntitiesModel*)value_;
- (void)removeTweetEntitiesUrlsObject:(MDPTweetEntitiesModel*)value_;
@end

@interface _MDPTweetUrlModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveDisplayUrl;
- (void)setPrimitiveDisplayUrl:(NSString*)value;

- (NSData*)primitiveIndices;
- (void)setPrimitiveIndices:(NSData*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveUrlAddress;
- (void)setPrimitiveUrlAddress:(NSString*)value;

- (NSMutableSet*)primitiveTweetEntitiesUrls;
- (void)setPrimitiveTweetEntitiesUrls:(NSMutableSet*)value;

@end
