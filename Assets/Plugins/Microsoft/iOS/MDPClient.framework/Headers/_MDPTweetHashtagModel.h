//
//  _MDPTweetHashtagModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPTweetHashtagModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPTweetHashtagModelAttributes {
	__unsafe_unretained NSString *indices;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *text;
} MDPTweetHashtagModelAttributes;

extern const struct MDPTweetHashtagModelRelationships {
	__unsafe_unretained NSString *tweetEntitiesHasTags;
} MDPTweetHashtagModelRelationships;

@class MDPTweetEntitiesModel;

@interface _MDPTweetHashtagModel : NSManagedObject

@property (nonatomic, strong) NSData* indices;

//- (BOOL)validateIndices:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* text;

//- (BOOL)validateText:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *tweetEntitiesHasTags;

- (NSMutableSet*)tweetEntitiesHasTagsSet;

@end

@interface _MDPTweetHashtagModel (TweetEntitiesHasTagsCoreDataGeneratedAccessors)
- (void)addTweetEntitiesHasTags:(NSSet*)value_;
- (void)removeTweetEntitiesHasTags:(NSSet*)value_;
- (void)addTweetEntitiesHasTagsObject:(MDPTweetEntitiesModel*)value_;
- (void)removeTweetEntitiesHasTagsObject:(MDPTweetEntitiesModel*)value_;
@end

@interface _MDPTweetHashtagModel (CoreDataGeneratedPrimitiveAccessors)

- (NSData*)primitiveIndices;
- (void)setPrimitiveIndices:(NSData*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveText;
- (void)setPrimitiveText:(NSString*)value;

- (NSMutableSet*)primitiveTweetEntitiesHasTags;
- (void)setPrimitiveTweetEntitiesHasTags:(NSMutableSet*)value;

@end
