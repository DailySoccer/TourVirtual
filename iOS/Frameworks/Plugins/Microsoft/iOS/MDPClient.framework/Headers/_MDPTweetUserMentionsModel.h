//
//  _MDPTweetUserMentionsModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPTweetUserMentionsModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPTweetUserMentionsModelAttributes {
	__unsafe_unretained NSString *indices;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *screenName;
} MDPTweetUserMentionsModelAttributes;

extern const struct MDPTweetUserMentionsModelRelationships {
	__unsafe_unretained NSString *tweetEntitiesUserMentions;
} MDPTweetUserMentionsModelRelationships;

@class MDPTweetEntitiesModel;

@interface _MDPTweetUserMentionsModel : NSManagedObject

@property (nonatomic, strong) NSData* indices;

//- (BOOL)validateIndices:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* screenName;

//- (BOOL)validateScreenName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *tweetEntitiesUserMentions;

- (NSMutableSet*)tweetEntitiesUserMentionsSet;

@end

@interface _MDPTweetUserMentionsModel (TweetEntitiesUserMentionsCoreDataGeneratedAccessors)
- (void)addTweetEntitiesUserMentions:(NSSet*)value_;
- (void)removeTweetEntitiesUserMentions:(NSSet*)value_;
- (void)addTweetEntitiesUserMentionsObject:(MDPTweetEntitiesModel*)value_;
- (void)removeTweetEntitiesUserMentionsObject:(MDPTweetEntitiesModel*)value_;
@end

@interface _MDPTweetUserMentionsModel (CoreDataGeneratedPrimitiveAccessors)

- (NSData*)primitiveIndices;
- (void)setPrimitiveIndices:(NSData*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveScreenName;
- (void)setPrimitiveScreenName:(NSString*)value;

- (NSMutableSet*)primitiveTweetEntitiesUserMentions;
- (void)setPrimitiveTweetEntitiesUserMentions:(NSMutableSet*)value;

@end
